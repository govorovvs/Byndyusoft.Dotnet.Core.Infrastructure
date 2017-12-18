namespace Byndyusoft.Extensions.Db.Sessions
{
    using System;
    using System.Data.Common;

    public class DbSession : ICommittableDbSession
    {
        private bool _disposed;

        public DbSession(DbConnection connection, DbTransaction transaction)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            Transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            Transaction?.Dispose();
            Transaction = null;

            Connection?.Dispose();
            Connection = null;

            _disposed = true;
        }

        public DbConnection Connection { get; private set; }

        public DbTransaction Transaction { get; private set; }

        public void Commit()
        {
            ThrowIfDisposed();

            Transaction.Commit();
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
        }
    }
}