using System;

namespace Dependable.Abstractions
{
	public interface IScope<out T> : IDisposable
	{
		T Value { get; }
	}
}