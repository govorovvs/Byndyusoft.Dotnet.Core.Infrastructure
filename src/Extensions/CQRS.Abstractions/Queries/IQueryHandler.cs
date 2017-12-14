namespace Byndyusoft.Extensions.CQRS.Queries
{ 
    /// <summary>
    /// Interface for query handlers
    /// </summary>
    /// <typeparam name="TQuery">Query type</typeparam>
    /// <typeparam name="TResult">Query result type</typeparam>
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Method for query execution
        /// </summary>
        /// <param name="query">Information needed for query execution</param>
        /// <returns>Query result</returns>
        TResult Ask(TQuery query);
    }
}