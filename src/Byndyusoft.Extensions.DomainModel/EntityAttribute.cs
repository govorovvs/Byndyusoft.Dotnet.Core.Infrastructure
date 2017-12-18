﻿namespace Byndyusoft.Extensions.DomainModel
{
    using System;

    /// <summary>
	/// An object that is not defined by its attributes, but rather by a thread of continuity and its identity.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface)]
	public class EntityAttribute : Attribute
	{
	}
}