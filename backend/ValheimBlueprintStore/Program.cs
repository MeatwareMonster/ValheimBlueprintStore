using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ValheimBlueprintStore.Extensions;
using ValheimBlueprintStore.Models;

namespace ValheimBlueprintStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase<ValheimBlueprintStoreContext>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
