namespace Byndyusoft.Extensions.CQRS
{
    using Commands;
    using Microsoft.Extensions.DependencyInjection;
    using Queries;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandlersFactory, CommandHandlersFactory>();
            services.AddTransient<ICommandsDispatcher, CommandsDispatcher>();
            services.AddTransient<IQueryHandlersFactory, QueryHandlersFactory>();
            services.AddTransient<IQueriesDispatcher, QueriesDispatcher>();

            return services;
        }
    }
}
