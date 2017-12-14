namespace Byndyusoft.Extensions.CQRS.Commands
{
    /// <summary>
    /// Interface for synchronous command handlers
    /// </summary>
    /// <typeparam name="TCommand">Command type</typeparam>
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Method for command execution
        /// </summary>
        /// <param name="command">Information needed for command execution</param>
        void Execute(TCommand command);
    }
}