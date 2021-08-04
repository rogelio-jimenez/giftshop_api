using GS.Identity;
using GS.Infrastructure;
using GS.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using GS.Application;
using Microsoft.Net.Http.Headers;
using GS.API.Extensions;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;

namespace GS.API
{
    public class Startup
    {
        private string coorsName = "Open";
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddSwagger(services);

            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);
            services.AddPersitanceServices(Configuration);
            services.AddIdentityServicesRegistration(Configuration);

            services.AddControllers();

            services.AddCors(opts =>
            {
                opts.AddPolicy(coorsName, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                .WithExposedHeaders(HeaderNames.ContentDisposition)
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins(Configuration["ClientDomains"].Split(',', StringSplitOptions.RemoveEmptyEntries))
            );

            var physicalFileProvider = Path.Combine(Directory.GetCurrentDirectory(), $@"{_env.WebRootPath}/{AppConstants.AssetsFolderName}");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(physicalFileProvider),
                RequestPath = new PathString($"/{AppConstants.AssetsFolderName}")
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("/swagger/v1/swagger.json", "GiftShop API");
            });

            app.UseAuthentication();
            app.UseAuthorization();

            // custom http error handling
            app.UseErrorHandlingMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(sg =>
            {
                sg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                sg.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme {
                        Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                sg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GiftShop API"
                });
                //sg.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }
    }
}
