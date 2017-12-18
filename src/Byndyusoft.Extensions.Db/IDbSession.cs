using System;

namespace Byndyusoft.Extensions.Db.Sessions
{
    using System.Data.Common;

    public interface IDbSession : IDisposable
    {
        DbConnection Connection { get; }

        DbTransaction Transaction { get; }
    }
}
