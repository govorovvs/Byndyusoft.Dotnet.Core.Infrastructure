namespace Byndyusoft.Extensions.Db.Sessions
{
    public interface ICommittableDbSession : IDbSession
    {
        void Commit();
    }
}