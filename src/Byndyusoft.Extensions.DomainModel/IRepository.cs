﻿namespace Byndyusoft.Extensions.DomainModel
{
	/// <summary>
	/// Marker interface.
	/// </summary>
	public interface IRepository
	{
	}

	/// <summary>
	/// A mechanism for encapsulating storage, retrieval, and search behavior which emulates a collection of objects.
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public interface IRepository<TEntity> : IRepository where TEntity : IAggregate
	{
	}
}