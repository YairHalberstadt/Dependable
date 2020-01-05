using Dependable.Abstractions;
using System;

namespace Dependable.Implementations.Manual
{
	internal class ManualScope<T> : IScope<T>
	{
		public ManualScope(T value)
		{
			Value = value;
		}

		public T Value { get; }

		public void Dispose()
		{
			(Value as IDisposable)?.Dispose();
		}
	}
}
