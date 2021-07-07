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
                options.UseSqlServer(configuration.GetConnectionString("AppConnection"))
            );
            return services;
        }
    }
}
