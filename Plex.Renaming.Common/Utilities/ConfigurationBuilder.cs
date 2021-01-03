using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Video.Renaming.Common.Models;

namespace Video.Renaming.Common.Utilities
{
    public static class ConfigurationBuilder
    {
        public static ServiceProvider BuildConfiguration(Action<ServiceCollection> servicesToAdd = null)
        {
            var environmentName = Environment.GetEnvironmentVariable("ENVIRONMENT");

            var configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            services.AddOptions();

            var config = new AppSettings();
            configuration.Bind(AppSettings.Section, config);
            services.AddSingleton(config);

            servicesToAdd?.Invoke(services);

            return services.BuildServiceProvider();
        }
    }
}