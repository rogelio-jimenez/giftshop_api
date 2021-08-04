using GS.Application.Contracts.Identity;
using GS.Application.Models.Authentication;
using GS.Application.Wrappers;
using GS.Identity.Models;
using GS.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;

namespace GS.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GiftShopIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Authentication"),
                b => b.MigrationsAssembly(typeof(GiftShopIdentityDbContext).Assembly.FullName))
            );

            services.AddIdentity<ApplicationUser, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = AuthConstants.MinPasswordLength;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<GiftShopIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddScoped<GiftShopIdentityInitializer>();

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddSingleton<TokenGenerator>();
            services.AddSingleton<RefreshTokenGenerator>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero, // It forces tokens to expire exactly at token expiration time
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };

                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnChallenge = context =>
                    {
                        if (!context.Response.HasStarted) {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject("401 Not authorized");
                            return context.Response.WriteAsync(result);
                        } else {
                            var result = JsonConvert.SerializeObject(new Response<string>("Token Expired"));
                            return context.Response.WriteAsync(result);
                        }
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new Response<string>("403 forbidden"));
                        return context.Response.WriteAsync(result);
                    },
                };
            });

            return services;

        }
    }
}
