namespace Byndyusoft.Extensions.CQRS.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for asynchronous command handlers
    /// </summary>
    /// <typeparam name="TCommand">Command type</typeparam>
    public interface IAsyncCommandHandler<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Method for command execution
        /// </summary>
        /// <param name="command">Information needed for command execution</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> object that represents the asynchronous operation.</returns>
        Task ExecuteAsync(TCommand command, CancellationToken cancellationToken);
    }
}