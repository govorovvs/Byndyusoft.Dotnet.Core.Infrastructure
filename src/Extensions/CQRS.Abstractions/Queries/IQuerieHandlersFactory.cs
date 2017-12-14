namespace Byndyusoft.Extensions.CQRS.Queries
{
    /// <summary>
    /// Query handlers factory interface
    /// </summary>
    public interface IQueryHandlersFactory
    {
        /// <summary>
        /// Method for query handlers creation
        /// </summary>
        /// <typeparam name="TQuery">Query query type</typeparam>
        /// <typeparam name="TResult">Query result type</typeparam>
        /// <returns>Query instance</returns>
        IQueryHandler<TQuery, TResult> Create<TQuery, TResult>() where TQuery : IQuery<TResult>;

        /// <summary>
        /// Method for async query handlers creation
        /// </summary>
        /// <typeparam name="TQuery">Query query type</typeparam>
        /// <typeparam name="TResult">Query result type</typeparam>
        /// <returns>Async query instance</returns>
        IAsyncQueryHandler<TQuery, TResult> CreateAsyncQuery<TQuery, TResult>() where TQuery : IQuery<TResult>;
    }
}