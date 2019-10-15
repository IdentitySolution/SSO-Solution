using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TemplateSourceName
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var clean = args.Any(x => x == "--clean");
            if (clean) args = args.Except(new[] { "--clean" }).ToArray();

            var seed = args.Any(x => x == "--seed");
            if (seed) args = args.Except(new[] { "--seed" }).ToArray();

            var dontRun = args.Any(x => x == "--dont-run");
            if (dontRun) args = args.Except(new[] { "--dont-run" }).ToArray();

            var host = CreateHostBuilder(args).Build();

            if (clean)
            {
                using var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
                Console.WriteLine("Cleaning!");
                SeedData.EnsureCleanData(scope.ServiceProvider);
            }

            if (seed)
            {
                using var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
                Console.WriteLine("Seeding!");
                SeedData.EnsureSeedData(scope.ServiceProvider);
            }

            if (dontRun) return;

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
