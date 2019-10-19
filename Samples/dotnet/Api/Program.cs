using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                .Build();

            var certificateSettings = config.GetSection("CertificateSettings");
            string certificateFile = certificateSettings.GetValue<string>("Filename");
            string certificatePassword = certificateSettings.GetValue<string>("Password");

#pragma warning disable IDE0067 // Dispose objects before losing scope. If disposed here, application will fail
            var certificate = new X509Certificate2(certificateFile, certificatePassword);
#pragma warning restore IDE0067 // Dispose objects before losing scope. If disposed here, application will fail

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(options =>
                    {
                        // options.Listen(IPAddress.Loopback,5002); // Normally used for HttpsRedirection, but we're not enabling for api
                        options.Listen(IPAddress.Loopback, 5003, listenOptions =>
                        {
                            listenOptions.UseHttps(certificate);
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
