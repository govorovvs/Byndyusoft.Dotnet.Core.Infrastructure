namespace Byndyusoft.Extensions.DomainModel
{
    using System;

    /// <summary>
	/// Aggregate is a cluster of domain objects that can be treated as a single unit. 
	/// </summary>
	/// <see href="http://martinfowler.com/bliki/DDD_Aggregate.html"/>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
	public class AggregateAttribute : Attribute
	{
		
	}
}