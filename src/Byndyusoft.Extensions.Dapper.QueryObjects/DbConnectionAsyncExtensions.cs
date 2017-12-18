namespace Byndyusoft.Extensions.Dapper
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Dapper;

    public static class DbConnectionAsyncExtensions
    {
        public static Task<IEnumerable<T>> QueryAsync<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QueryAsync<T>(command);
        }

        public static Task<IEnumerable<dynamic>> QueryAsync(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QueryAsync(command);
        }

        public static Task<T> QueryFirstAsync<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QueryFirstAsync<T>(command);
        }

        public static Task<dynamic> QueryFirstAsync(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QueryFirstAsync(command);
        }

        public static Task<T> QueryFirstOrDefaultAsync<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QueryFirstOrDefaultAsync<T>(command);
        }

        public static Task<dynamic> QueryFirstOrDefaultAsync(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QueryFirstOrDefaultAsync(command);
        }

        public static Task<T> QuerySingleAsync<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QuerySingleAsync<T>(command);
        }

        public static Task<dynamic> QuerySingleAsync(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QuerySingleAsync(command);
        }

        public static Task<T> QuerySingleOrDefaultAsync<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QuerySingleOrDefaultAsync<T>(command);
        }

        public static Task<dynamic> QuerySingleOrDefaultAsync(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QuerySingleOrDefaultAsync(command);
        }

        public static Task<SqlMapper.GridReader> QueryMultipleAsync(this IDbConnection connection, QueryObject queryObject,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = CreateCommand(queryObject, transaction, commandTimeout, commandType, cancellationToken);
            return connection.QueryMultipleAsync(command);
        }

        private static CommandDefinition CreateCommand(QueryObject queryObject, IDbTransaction transaction,
            int? commandTimeout, CommandType? commandType, CancellationToken cancellationToken)
        {
            return new CommandDefinition(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout,
                commandType, cancellationToken: cancellationToken);
        }
    }
}