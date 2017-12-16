using Xunit;

namespace CQRS.Tests
{
    using Byndyusoft.Extensions.CQRS;
    using Byndyusoft.Extensions.CQRS.Commands;
    using Byndyusoft.Extensions.CQRS.Queries;
    using Microsoft.Extensions.DependencyInjection;


    public class ServiceCollectionTests
    {
        [Fact]
        public void CommandsDispatcher_Registration_Test()
        {
            var services = new ServiceCollection()
                .AddCqrs()
                .BuildServiceProvider();

            var dispatcher = services.GetService<ICommandsDispatcher>();

            Assert.IsType<CommandsDispatcher>(dispatcher);
        }

        [Fact]
        public void CommandHandlersFactory_Registration_Test()
        {
            var services = new ServiceCollection()
                .AddCqrs()
                .BuildServiceProvider();

            var factory = services.GetService<ICommandHandlersFactory>();

            Assert.IsType<CommandHandlersFactory>(factory);
        }

        [Fact]
        public void QueriesDispatcher_Registration_Test()
        {
            var services = new ServiceCollection()
                .AddCqrs()
                .BuildServiceProvider();

            var dispatcher = services.GetService<IQueriesDispatcher>();

            Assert.IsType<QueriesDispatcher>(dispatcher);
        }

        [Fact]
        public void QueryHandlersFactory_Registration_Test()
        {
            var services = new ServiceCollection()
                .AddCqrs()
                .BuildServiceProvider();

            var factory = services.GetService<IQueryHandlersFactory>();

            Assert.IsType<QueryHandlersFactory>(factory);
        }
    }
}
