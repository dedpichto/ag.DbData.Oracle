using ag.DbData.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ag.DbData.Oracle.Services
{
    /// <summary>
    /// Represents <see cref="OracleStringProviderFactory"/> object.
    /// </summary>
    public class OracleStringProviderFactory : IDbDataStringProviderFactory<OracleStringProvider>
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates new instance of <see cref="OracleStringProviderFactory"/>.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        public OracleStringProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Creates object of type <see cref="OracleStringProvider"/>.
        /// </summary>
        /// <returns>Object of type <see cref="OracleStringProvider"/>.</returns>
        public OracleStringProvider Get()
        {
            return _serviceProvider.GetService<OracleStringProvider>();
        }
    }
}
