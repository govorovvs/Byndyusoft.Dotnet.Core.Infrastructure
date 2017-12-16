namespace Byndyusoft.Extensions.CQRS.Commands
{
    using System;

    public class CommandHandlersFactory : ICommandHandlersFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandHandlersFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public object CreateHandler(Type handlerType)
        {
            return _serviceProvider.GetService(handlerType);
        }
    }
}