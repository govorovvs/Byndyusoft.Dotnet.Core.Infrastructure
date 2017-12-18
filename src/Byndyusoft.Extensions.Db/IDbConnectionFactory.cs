namespace Byndyusoft.Extensions.Db.Sessions
{
    using System.Data.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDbConnectionFactory
    {
        DbConnection Create();

        Task<DbConnection> CreateAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}