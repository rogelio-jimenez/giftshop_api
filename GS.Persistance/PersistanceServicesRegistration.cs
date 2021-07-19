using GS.Application.Contracts.Persistence;
using GS.Application.Infrastructure;
using GS.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GS.Persistance
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection AddPersitanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GiftShopDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppConnection"),
                b => b.MigrationsAssembly(typeof(GiftShopDBContext).Assembly.FullName))
            );

            services.AddScoped<GiftShopDbContextInitializer>();

            services.AddTransient<IRepository, EfRepository<GiftShopDBContext>>();
            services.AddTransient<IReadOnlyRepository, EfReadOnlyRepository<GiftShopDBContext>>();
            services.AddSingleton<IPaginator, DefaultPagination>();

            return services;
        }
    }
}
