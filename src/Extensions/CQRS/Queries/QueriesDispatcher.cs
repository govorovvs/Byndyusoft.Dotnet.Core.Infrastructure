namespace Byndyusoft.Extensions.CQRS.Queries
{
    using System;
    using System.Reflection;
    using System.Runtime.ExceptionServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class QueriesDispatcher : IQueriesDispatcher
    {
        private readonly IQueryHandlersFactory _handlersFactory;

        public QueriesDispatcher(IQueryHandlersFactory handlersFactory)
        {
            _handlersFactory = handlersFactory ?? throw new ArgumentNullException(nameof(handlersFactory));
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            BeforeExecute(query);
            var result = DoExecute(query);
            AfterExecute(query, ref result);
            return result;
        }

        public Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return ExecuteAsync(query, CancellationToken.None);
        }

        public async Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            await BeforeExecuteAsync(query, cancellationToken).ConfigureAwait(false);
            var result = await DoExecuteAsync(query, cancellationToken).ConfigureAwait(false);
            return await AfterExecuteAsync(query, result, cancellationToken).ConfigureAwait(false);
        }

        protected virtual Task BeforeExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        {
            BeforeExecute(query);
            return Task.FromResult(0);
        }

        protected virtual Task<TResult> AfterExecuteAsync<TResult>(IQuery<TResult> query, TResult result, CancellationToken cancellationToken)
        {
            AfterExecute(query, ref result);
            return Task.FromResult(result);
        }

        protected virtual void AfterExecute<TResult>(IQuery<TResult> query, ref TResult result)
        {
        }

        protected virtual void BeforeExecute<TResult>(IQuery<TResult> query)
        {
        }

        private TResult DoExecute<TResult>(IQuery<TResult> query)
        {
            var queryType = query.GetType();
            var resultType = typeof(TResult);

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, resultType);
            var handler = _handlersFactory.CreateHandler(handlerType);
            var methodName = nameof(IQueryHandler<IQuery<TResult>, TResult>.Ask);
            var method = handlerType.GetRuntimeMethod(methodName, new[] {queryType});

            try
            {
                return (TResult) method.Invoke(handler, new object[] {query});
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }

        private Task<TResult> DoExecuteAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken)
        {
            var queryType = query.GetType();
            var resultType = typeof(TResult);

            var handlerType = typeof(IAsyncQueryHandler<,>).MakeGenericType(queryType, resultType);
            var handler = _handlersFactory.CreateHandler(handlerType);
            var methodName = nameof(IAsyncQueryHandler<IQuery<TResult>, TResult>.AskAsync);
            var method = handlerType.GetRuntimeMethod(methodName, new[] {queryType, cancellationToken.GetType()});

            try
            {
                return (Task<TResult>) method.Invoke(handler, new object[] {query, cancellationToken});
            }
            catch (TargetInvocationException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                throw;
            }
        }
    }
}