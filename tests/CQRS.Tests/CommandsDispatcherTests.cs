namespace CQRS.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Byndyusoft.Extensions.CQRS;
    using Byndyusoft.Extensions.CQRS.Commands;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Xunit;

    public class CommandsDispatcherTests
    {
        private readonly CancellationToken _cancellationToken;

        public CommandsDispatcherTests()
        {
            _cancellationToken = new CancellationTokenSource().Token;
        }

        [Fact]
        public void Execute_Command_Test()
        {
            var command = new FakeCommand();
            var mockHandler = new Mock<ICommandHandler<FakeCommand>>();
            mockHandler.Setup(x => x.Execute(command));

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<ICommandsDispatcher>();
            dispatcher.Execute(command);

            mockHandler.VerifyAll();
        }

        [Fact]
        public void Execute_Command_By_Base_Command_Reference_Test()
        {
            var command = new FakeCommand();
            var mockHandler = new Mock<ICommandHandler<FakeCommand>>();
            mockHandler.Setup(x => x.Execute(command));

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<ICommandsDispatcher>();
            dispatcher.Execute<BaseCommand>(command);

            mockHandler.VerifyAll();
        }

        [Fact]
        public void Execute_Exception_Test()
        {
            var exception = new Exception();
            var command = new FakeCommand();
            var mockHandler = new Mock<ICommandHandler<FakeCommand>>();
            mockHandler.Setup(x => x.Execute(command)).Throws(exception);

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<ICommandsDispatcher>();

            var thrownException = Assert.Throws<Exception>(() => dispatcher.Execute(command));
            Assert.Equal(exception, thrownException);
        }

        [Fact]
        public async Task ExecuteAsync_Command_Text()
        {
            var command = new FakeCommand();
            var mockHandler = new Mock<IAsyncCommandHandler<FakeCommand>>();
            mockHandler.Setup(x => x.ExecuteAsync(command, _cancellationToken)).Returns(Task.CompletedTask);

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<ICommandsDispatcher>();
            await dispatcher.ExecuteAsync(command, _cancellationToken);

            mockHandler.VerifyAll();
        }

        [Fact]
        public async Task ExecuteAsync_Command_By_Base_Command_Reference_Test()
        {
            var command = new FakeCommand();
            var mockHandler = new Mock<IAsyncCommandHandler<FakeCommand>>();
            mockHandler.Setup(x => x.ExecuteAsync(command, _cancellationToken)).Returns(Task.CompletedTask);

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<ICommandsDispatcher>();
            await dispatcher.ExecuteAsync<BaseCommand>(command, _cancellationToken);

            mockHandler.VerifyAll();
        }

        [Fact]
        public async Task ExecuteAsync_Exception_Test()
        {
            var exception = new Exception();
            var command = new FakeCommand();
            var mockHandler = new Mock<IAsyncCommandHandler<FakeCommand>>();
            mockHandler.Setup(x => x.ExecuteAsync(command, _cancellationToken)).Throws(exception);

            var services = new ServiceCollection()
                .AddCqrs()
                .AddSingleton(mockHandler.Object)
                .BuildServiceProvider();

            var dispatcher = services.GetService<ICommandsDispatcher>();

            var thrownException = await Assert.ThrowsAsync<Exception>(() => dispatcher.ExecuteAsync(command, _cancellationToken));
            Assert.Equal(exception, thrownException);
        }

        public class BaseCommand : ICommand
        {
        }

        public class FakeCommand : BaseCommand
        {
        }
    }
}