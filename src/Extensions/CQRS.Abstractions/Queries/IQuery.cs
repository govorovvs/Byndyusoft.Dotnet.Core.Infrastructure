namespace Byndyusoft.Extensions.CQRS.Queries
{
    /// <summary>
    /// Interface for queries marking
    /// </summary>
    /// <typeparam name="TResult">Query result type</typeparam>
    public interface IQuery<out TResult>
    {
    }
}