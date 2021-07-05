using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Persistance
{
    public static class PersistanceServicesRegistration
    {
        public static IServiceCollection AddPersitanceServices(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
