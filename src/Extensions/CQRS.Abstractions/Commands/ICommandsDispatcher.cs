namespace Byndyusoft.Extensions.CQRS.Commands
{ 
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
        /// <param name="commandContext">Information needed for commands execution</param>
        void Execute<TCommand>(TCommand commandContext) where TCommand : ICommand;

        /// <summary>
        /// Method for asynchronous commands execution
        /// </summary>
        /// <typeparam name="TCommand">Command context type</typeparam>
        /// <param name="commandContext">Information needed for commands execution</param>
        Task ExecuteAsync<TCommand>(TCommand commandContext) where TCommand : ICommand;
    }
}