namespace Byndyusoft.Extensions.CQRS.Commands
{
    using System;

    /// <summary>
    /// Command handlers factory interface
    /// </summary>
    public interface ICommandHandlersFactory
    {
        /// <summary>
        /// Method for synchronous command handlers creation
        /// </summary>
        /// <returns>Command handler instance</returns>
        object CreateHandler(Type handlerType);
    }
}