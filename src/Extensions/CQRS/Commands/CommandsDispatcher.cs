namespace Byndyusoft.Extensions.CQRS.Commands
{
    using System;
    using System.Reflection;
    using System.Runtime.ExceptionServices;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Commands dispatcher standard implementation
    /// </summary>
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly ICommandHandlersFactory _handlersFactory;

        /// <summary>
        /// Constructor for commands dispatcher
        /// </summary>
        /// <param name="commandsFactory">Commands factory</param>
        public CommandsDispatcher(ICommandHandlersFactory commandsFactory)
        {
            _handlersFactory = commandsFactory ?? throw new ArgumentNullException(nameof(commandsFactory));
        }

        /// <summary>
        /// Method for synchronous commands execution
        /// </summary>
        /// <typeparam name="TCommand">Command context type</typeparam>
        /// <param name="command">Information needed for commands execution</param>
        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            BeforeExecute(command);
            DoExecute(command);
            AfterExecute(command);
        }

        /// <summary>
        /// Method for asynchronous commands execution
        /// </summary>
        /// <typeparam name="TCommand">Command context type</typeparam>
        /// <param name="command">Information needed for commands execution</param>
        public Task ExecuteAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            return ExecuteAsync(command, CancellationToken.None);
        }

        public async Task ExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            await BeforeExecuteAsync(command, cancellationToken).ConfigureAwait(false);
            await DoExecuteAsync(command, cancellationToken).ConfigureAwait(false);
            await AfterExecuteAsync(command, cancellationToken).ConfigureAwait(false);
        }

        protected virtual void BeforeExecute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
        }

        protected virtual Task BeforeExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
        {
            BeforeExecute(command);
            return Task.CompletedTask;
        }

        protected virtual void AfterExecute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
        }

        protected virtual Task AfterExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
        {
            AfterExecute(command);
            return Task.CompletedTask;
        }

        private void DoExecute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var commandType = command.GetType();
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
            var genericHandler = _handlersFactory.CreateHandler(handlerType);
            var methodName = nameof(ICommandHandler<TCommand>.Execute);
            var method = handlerType.GetRuntimeMethod(methodName, new[] { commandType });

            try
            {
                method.Invoke(genericHandler, new object[] { command });
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }

        private Task DoExecuteAsync<TCommand>(TCommand command, CancellationToken cancellationToken)
            where TCommand : ICommand
        {
            Type commandType = command.GetType();
            var handlerType = typeof(IAsyncCommandHandler<>).MakeGenericType(commandType);
            var handler = _handlersFactory.CreateHandler(handlerType);
            var methodName = nameof(IAsyncCommandHandler<TCommand>.ExecuteAsync);
            var method = handlerType.GetRuntimeMethod(methodName, new[] {commandType, cancellationToken.GetType()});

            try
            {
                return (Task) method.Invoke(handler, new object[] {command, cancellationToken});
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }
    }
}