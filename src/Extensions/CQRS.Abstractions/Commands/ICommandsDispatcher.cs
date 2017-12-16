namespace Byndyusoft.Extensions.CQRS.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Commands dispatcher interface
    /// </summary>
    public interface ICommandsDispatcher
    {
        /// <summary>
        /// Method for synchronous commands execution
        /// </summary>
        /// <typeparam name="TCommand">Command context type</typeparam>
        /// <param name="command">Information needed for commands execution</param>
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;

        /// <summary>
        /// Method for asynchronous commands execution
        /// </summary>
        /// <typeparam name="TCommand">Command context type</typeparam>
        /// <param name="command">Information needed for commands execution</param>
        Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand;

        /// <summary>
        /// Method for asynchronous commands execution
        /// </summary>
        /// <typeparam name="TCommand">Command context type</typeparam>
        /// <param name="command">Information needed for commands execution</param>
        /// <param name="cancellationToken"></param>
        Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;
    }
}