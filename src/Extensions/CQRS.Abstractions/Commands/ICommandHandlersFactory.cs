namespace Byndyusoft.Extensions.CQRS.Commands
{ 
    /// <summary>
    /// Command handlers factory interface
    /// </summary>
    public interface ICommandHandlersFactory
    {
        /// <summary>
        /// Method for synchronous command handlers creation
        /// </summary>
        /// <typeparam name="TCommand">Command type</typeparam>
        /// <returns>Command handler instance</returns>
        ICommandHandler<TCommand> CreateCommand<TCommand>() where TCommand : ICommand;

        /// <summary>
        /// Method for asynchronous command handlers creation
        /// </summary>
        /// <typeparam name="TCommand">Command type</typeparam>
        /// <returns>Command handler instance</returns>
        IAsyncCommandHandler<TCommand> CreateAsyncCommand<TCommand>() where TCommand : ICommand;
    }
}