using GS.Identity;
using GS.Persistance.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
                await appDbContextInitializer.Run();
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
