using GS.Application.Contracts.Repository;
using GS.Persistance.Contexts;
using GS.Persistance.Repository;
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
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(GiftShopRepositoryAsync<>));
            
            return services;
        }
    }
}
