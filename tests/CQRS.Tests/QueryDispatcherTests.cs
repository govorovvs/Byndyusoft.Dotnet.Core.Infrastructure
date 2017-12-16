namespace CQRS.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Byndyusoft.Extensions.CQRS;
    using Byndyusoft.Extensions.CQRS.Queries;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Xunit;

    public class QueryDispatcherTests
    {
        private readonly CancellationToken _cancellationToken;

        public QueryDispatcherTests()
        {
            _cancellationToken = new CancellationTokenSource().Token;
        }

        [Fact]
        public void Execute_Test()
        {
            var query = new FakeQuery();
            var mockHandler = new Mock<IQueryHandler<FakeQuery,int>>();
            mockHandler.Setup(x => x.Ask(query)).Returns(10);

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<IQueriesDispatcher>();
            var result = dispatcher.Execute(query);

            Assert.Equal(10, result);
        }

        [Fact]
        public void Execute_Exception_Test()
        {
            var exception = new Exception();
            var query = new FakeQuery();
            var mockHandler = new Mock<IQueryHandler<FakeQuery, int>>();
            mockHandler.Setup(x => x.Ask(query)).Throws(exception);

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<IQueriesDispatcher>();
            var thrownException = Assert.Throws<Exception>(() => dispatcher.Execute(query));

            Assert.Same(exception, thrownException);
        }


        [Fact]
        public async Task ExecuteAsync_Test()
        {
            var query = new FakeQuery();
            var mockHandler = new Mock<IAsyncQueryHandler<FakeQuery, int>>();
            mockHandler.Setup(x => x.AskAsync(query, _cancellationToken)).ReturnsAsync(10);

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<IQueriesDispatcher>();
            var result = await dispatcher.ExecuteAsync(query, _cancellationToken);

            Assert.Equal(10, result);
        }

        [Fact]
        public async Task ExecuteAsync_Exception_Test()
        {
            var exception = new Exception();
            var query = new FakeQuery();
            var mockHandler = new Mock<IAsyncQueryHandler<FakeQuery, int>>();
            mockHandler.Setup(x => x.AskAsync(query, _cancellationToken)).Throws(exception);

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<IQueriesDispatcher>();
            var thrownException = await Assert.ThrowsAsync<Exception>(() => dispatcher.ExecuteAsync(query, _cancellationToken));

            Assert.Same(exception, thrownException);
        }

        public class BaseQuery : IQuery<int>
        {
        }

        public class FakeQuery : BaseQuery
        {
        }
    }
}