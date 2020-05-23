using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_ValuateAPI.DataModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace E_ValuateAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
           IHost host = CreateHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider serviceProvider = scope.ServiceProvider;
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var logger = serviceProvider.GetService<ILogger<Program>>();

                if (configuration.GetValue("EnsureDatabaseCreated", defaultValue: false) is true)
                {
                    logger.LogInformation("Ensuring database is created...");
                    try
                    {
                        var dbContext = serviceProvider.GetRequiredService<EvalContext>();
                        dbContext.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                        logger.LogCritical("Error while ensuring database is created.", ex);
                        throw;
                    }
                    logger.LogInformation("Ensured database is created.");
                }
                else
                {
                    logger.LogInformation("Not ensuring database is created.");
                }
            }

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
