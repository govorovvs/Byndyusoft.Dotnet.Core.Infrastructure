namespace Byndyusoft.Extensions.Db.Sessions
{
    using System.Collections.Generic;
    using System.Data;
    using Dapper;
    using global::Dapper;

    public static class DbSessionQueryObjectExtensions
    {
        public static IEnumerable<T> Query<T>(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.Query<T>(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static IEnumerable<dynamic> Query(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.Query(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static T QueryFirst<T>(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.QueryFirst<T>(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static dynamic QueryFirst(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.QueryFirst(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static T QueryFirstOrDefault<T>(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.QueryFirstOrDefault<T>(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static dynamic QueryFirstOrDefault(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.QueryFirstOrDefault(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static T QuerySingle<T>(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.QuerySingle<T>(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static dynamic QuerySingle(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.QuerySingle(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static T QuerySingleOrDefault<T>(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.QuerySingleOrDefault<T>(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static dynamic QuerySingleOrDefault(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.QuerySingleOrDefault(queryObject, session.Transaction, commandTimeout,
                commandType);
        }

        public static void Execute(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            session.Connection.Execute(queryObject, session.Transaction, commandTimeout, commandType);
        }

        public static SqlMapper.GridReader QueryMultiple(
            this IDbSession session, QueryObject queryObject, int? commandTimeout = null, CommandType? commandType = null)
        {
            return session.Connection.QueryMultiple(queryObject, session.Transaction, commandTimeout, commandType);
        }
    }
}