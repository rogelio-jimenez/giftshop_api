using GS.Identity;
using GS.Persistance.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace GS.API
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                var identityInitializer = scope.ServiceProvider.GetRequiredService<GiftShopIdentityInitializer>();
                var appDbContextInitializer = scope.ServiceProvider.GetRequiredService<GiftShopDbContextInitializer>();
                var cfg = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                await identityInitializer.Run(cfg["AdminMail"]);

                //ToDo: get the user id by email and pass to the following method...
                await appDbContextInitializer.Run(Guid.Parse("c31de770-af00-442b-be2e-bd6e5dffde03"));
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
