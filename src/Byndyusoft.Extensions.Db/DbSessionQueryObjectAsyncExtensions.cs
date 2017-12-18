namespace Byndyusoft.Extensions.Db.Sessions
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;
    using Dapper;
    using global::Dapper;

    public static class DbSessionQueryObjectAsyncExtensions
    {
        public static Task<IEnumerable<T>> QueryAsync<T>(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QueryAsync<T>(command);
        }

        public static Task<IEnumerable<dynamic>> QueryAsync(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QueryAsync(command);
        }

        public static Task<T> QueryFirstAsync<T>(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QueryFirstAsync<T>(command);
        }

        public static Task<dynamic> QueryFirstAsync(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QueryFirstAsync(command);
        }

        public static Task<T> QueryFirstOrDefaultAsync<T>(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QueryFirstOrDefaultAsync<T>(command);
        }

        public static Task<dynamic> QueryFirstOrDefaultAsync(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QueryFirstOrDefaultAsync(command);
        }

        public static Task<T> QuerySingleAsync<T>(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QuerySingleAsync<T>(command);
        }

        public static Task<dynamic> QuerySingleAsync(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QuerySingleAsync(command);
        }

        public static Task<T> QuerySingleOrDefaultAsync<T>(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QuerySingleOrDefaultAsync<T>(command);
        }

        public static Task<dynamic> QuerySingleOrDefaultAsync(this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QuerySingleOrDefaultAsync(command);
        }

        public static Task<SqlMapper.GridReader> QueryMultipleAsync(this IDbSession session, QueryObject queryObject,
            int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.QueryMultipleAsync(command);
        }

        public static Task ExecuteAsync(this IDbSession session, QueryObject queryObject,
            int? commandTimeout = null, CommandType? commandType = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, session.Transaction, commandTimeout, commandType, cancellationToken);
            return session.Connection.ExecuteAsync(command);
        }

        private static CommandDefinition CreateCommand(QueryObject queryObject, IDbTransaction transaction,
            int? commandTimeout, CommandType? commandType, CancellationToken cancellationToken)
        {
            return new CommandDefinition(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout,
                commandType, cancellationToken: cancellationToken);
        }
    }
}