using ag.DbData.Abstraction;
using ag.DbData.Abstraction.Services;
using ag.DbData.Oracle.Factories;
using ag.DbData.Oracle.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ag.DbData.Oracle.Extensions
{
    /// <summary>
    /// Represents <see cref="ag.DbData.Oracle"/> extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Appends the registration of <see cref="OracleDbDataFactory"/> and <see cref="OracleDbDataObject"/> services to <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgOracle(this IServiceCollection services)
        {
            services.AddSingleton<OracleStringProvider>();
            services.AddSingleton<IDbDataStringProviderFactory<OracleStringProvider>, OracleStringProviderFactory>();
            services.AddSingleton<IOracleDbDataFactory, OracleDbDataFactory>();
            services.AddTransient<OracleDbDataObject>();
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="OracleDbDataFactory"/> and <see cref="OracleDbDataObject"/> services to <see cref="IServiceCollection"/> and registers a configuration instance.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configurationSection">The <see cref="IConfigurationSection"/> being bound.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgOracle(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddAgOracle();
            services.Configure<DbDataSettings>(configurationSection);
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="OracleDbDataFactory"/> and <see cref="OracleDbDataObject"/> services to <see cref="IServiceCollection"/> and configures the options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureOptions">The action used to configure the options.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgOracle(this IServiceCollection services,
            Action<DbDataSettings> configureOptions)
        {
            services.AddAgOracle();
            services.Configure(configureOptions);
            return services;
        }
    }
}
