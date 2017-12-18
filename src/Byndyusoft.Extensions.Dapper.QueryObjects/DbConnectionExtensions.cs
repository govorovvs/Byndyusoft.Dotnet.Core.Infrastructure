namespace Byndyusoft.Extensions.Dapper
{
    using System.Collections.Generic;
    using System.Data;
    using global::Dapper;


    public static class DbConnectionExtensions
    {
        public static IEnumerable<T> Query<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.Query<T>(queryObject.Sql, queryObject.QueryParams, transaction, true, commandTimeout, commandType);
        }

        public static IEnumerable<dynamic> Query(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.Query(queryObject.Sql, queryObject.QueryParams, transaction, true, commandTimeout, commandType);
        }

        public static T QueryFirst<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.QueryFirst<T>(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
        }

        public static dynamic QueryFirst(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.QueryFirst(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
        }

        public static T QueryFirstOrDefault<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.QueryFirstOrDefault<T>(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
        }

        public static dynamic QueryFirstOrDefault(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.QueryFirstOrDefault(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
        }

        public static T QuerySingle<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.QuerySingle<T>(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
        }

        public static dynamic QuerySingle(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.QuerySingle(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
        }

        public static T QuerySingleOrDefault<T>(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.QuerySingleOrDefault<T>(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
        }

        public static dynamic QuerySingleOrDefault(this IDbConnection connection, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.QuerySingleOrDefault(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
        }

        public static SqlMapper.GridReader QueryMultiple(this IDbConnection connection, QueryObject queryObject,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return connection.QueryMultiple(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout,
                commandType);
        }
    }
}