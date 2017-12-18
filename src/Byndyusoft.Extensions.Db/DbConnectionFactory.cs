namespace Byndyusoft.Extensions.Db.Sessions
{
    using System;
    using System.Data.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public class DbConnectionFactory : IDbConnectionFactory
    {
        public DbConnectionFactory(DbProviderFactory providerFactory, string connectionString)
        {
            ProviderFactory = providerFactory ?? throw new ArgumentNullException(nameof(providerFactory));
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public DbProviderFactory ProviderFactory { get; }

        public string ConnectionString { get; }

        public DbConnection Create()
        {
            var connection = ProviderFactory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            try
            {
                connection.Open();
                return connection;
            }
            catch 
            {
                connection.Dispose();
                throw;
            }
        }

        public async Task<DbConnection> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var connection = ProviderFactory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            try
            {
                await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                return connection;
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }
    }
}