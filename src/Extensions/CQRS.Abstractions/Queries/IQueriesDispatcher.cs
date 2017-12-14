namespace Byndyusoft.Extensions.CQRS.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Queries dispatcher interface
    /// </summary>
    public interface IQueriesDispatcher
    {
        /// <summary>
        /// Method for queries execution
        /// </summary>
        /// <typeparam name="TResult">Query result type</typeparam>
        /// <param name="query">Information needed for queries execution</param>
        /// <returns>Query result</returns>
        TResult Execute<TResult>(IQuery<TResult> query); 

        /// <summary>
        /// Method for asynchronous queries execution
        /// </summary>
        /// <typeparam name="TResult">Query result type</typeparam>
        /// <param name="query">Information needed for queries execution</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query);

        /// <summary>
        /// Method for asynchronous queries execution
        /// </summary>
        /// <typeparam name="TResult">Query result type</typeparam>
        /// <param name="query">Information needed for queries execution</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while waiting for a task to complete.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken);
    }
}