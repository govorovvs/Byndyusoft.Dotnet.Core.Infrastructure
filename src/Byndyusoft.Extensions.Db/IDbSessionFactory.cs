namespace Byndyusoft.Extensions.Db.Sessions
{
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDbSessionFactory
    {
        IDbSession Create();
        IDbSession Create(IsolationLevel isolationLevel);

        ICommittableDbSession CreateCommittable();
        ICommittableDbSession CreateCommittable(IsolationLevel isolationLevel);

        Task<IDbSession> CreateAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<IDbSession> CreateAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default(CancellationToken));

        Task<ICommittableDbSession> CreateCommittableAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<ICommittableDbSession> CreateCommittableAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default(CancellationToken));
    }
}