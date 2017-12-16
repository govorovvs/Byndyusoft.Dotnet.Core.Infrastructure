namespace Byndyusoft.Extensions.CQRS.Queries
{
    using System;

    /// <summary>
    /// Query handlers factory interface
    /// </summary>
    public interface IQueryHandlersFactory
    {
        object CreateHandler(Type handlerType);
    }
}