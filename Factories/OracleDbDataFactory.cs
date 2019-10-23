using ag.DbData.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using System;

namespace ag.DbData.Oracle.Factories
{
    /// <summary>
    /// Represents OracleDbDataFactory object.
    /// </summary>
    internal class OracleDbDataFactory : IOracleDbDataFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates object of type <see cref="OracleDbDataObject"/>.
        /// </summary>
        /// <returns><see cref="OracleDbDataObject"/> implementation of <see cref="IDbDataObject"/> interface.</returns>
        public IDbDataObject Create()
        {
            var dbObject = _serviceProvider.GetService<OracleDbDataObject>();
            return dbObject;
        }

        /// <summary>
        /// Creates object of type <see cref="OracleDbDataObject"/>.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        /// <returns><see cref="OracleDbDataObject"/> implementation of <see cref="IDbDataObject"/> interface.</returns>
        public IDbDataObject Create(string connectionString)
        {
            var dbObject = _serviceProvider.GetService<OracleDbDataObject>();
            dbObject.Connection = new OracleConnection(connectionString);
            return dbObject;
        }
        
        /// <summary>
        /// Creates new OracleDbDataFactory object.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        public OracleDbDataFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
