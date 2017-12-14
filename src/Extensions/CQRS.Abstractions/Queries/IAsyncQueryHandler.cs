namespace Byndyusoft.Extensions.CQRS.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for async query handlers
    /// </summary>
    /// <typeparam name="TQuery">Query type</typeparam>
    /// <typeparam name="TResult">Query result type</typeparam>
    public interface IAsyncQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Method for query execution
        /// </summary>
        /// <param name="query">Information needed for query execution</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task<TResult> AskAsync(TQuery query, CancellationToken cancellationToken);
    }
}