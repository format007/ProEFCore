using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ch21.Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ch21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Main starting...");
            host.Run();
            logger.LogInformation("Main started");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(cfg =>
                {
                    cfg.ClearProviders();
                    cfg.SetMinimumLevel(LogLevel.Debug);
                    cfg.AddConsole();
                    cfg.AddProvider(new FileLoggerProvider(Path.Combine(Environment.CurrentDirectory, "logger.log")));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
