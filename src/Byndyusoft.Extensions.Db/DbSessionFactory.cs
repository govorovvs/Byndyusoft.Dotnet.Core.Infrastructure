namespace Byndyusoft.Extensions.Db.Sessions
{
    using System;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class DbSessionFactory : IDbSessionFactory
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DbSessionFactory(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public IDbSession Create()
        {
            return Create(IsolationLevel.Unspecified);
        }

        public IDbSession Create(IsolationLevel isolationLevel)
        {
            return CreateCommittable(isolationLevel);
        }

        public ICommittableDbSession CreateCommittable()
        {
            return CreateCommittable(IsolationLevel.Unspecified);
        }

        public ICommittableDbSession CreateCommittable(IsolationLevel isolationLevel)
        {
            var connection = _connectionFactory.Create();
            try
            {
                var transaction = connection.BeginTransaction(isolationLevel);
                return new DbSession(connection, transaction);
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }

        public Task<IDbSession> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return CreateAsync(IsolationLevel.Unspecified, cancellationToken);
        }

        public async Task<IDbSession> CreateAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken)
        {
            var session = await CreateCommittableAsync(isolationLevel, cancellationToken).ConfigureAwait(false);
            return session;
        }

        public Task<ICommittableDbSession> CreateCommittableAsync(CancellationToken cancellationToken)
        {
            return CreateCommittableAsync(IsolationLevel.Unspecified, cancellationToken);
        }

        public async Task<ICommittableDbSession> CreateCommittableAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken)
        {
            var connection = await _connectionFactory.CreateAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var transaction = connection.BeginTransaction(isolationLevel);
                return new DbSession(connection, transaction);
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }
    }
}