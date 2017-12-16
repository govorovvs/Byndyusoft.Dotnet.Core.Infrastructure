namespace Byndyusoft.Extensions.CQRS.Queries
{
    using System;

    public class QueryHandlersFactory : IQueryHandlersFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryHandlersFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object CreateHandler(Type handlerType)
        {
            return _serviceProvider.GetService(handlerType);
        }
    }
}