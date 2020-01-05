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

	public class ManualScopeFactory<TValue> : IScopeFactory<TValue>
	{
		private readonly Func<TValue> _func;

		public ManualScopeFactory(Func<TValue> func)
		{
			_func = func;
		}

		public IScope<TValue> CreateScope()
		{
			return new ManualScope<TValue>(_func());
		}
	}

	public class ManualScopeFactory<TParam1, TValue> : IScopeFactory<TParam1, TValue>
	{
		private readonly Func<TParam1, TValue> _func;

		public ManualScopeFactory(Func<TParam1, TValue> func)
		{
			_func = func;
		}

		public IScope<TValue> CreateScope(TParam1 param1)
		{
			return new ManualScope<TValue>(_func(param1));
		}
	}

	public class ManualScopeFactory<TParam1, TParam2, TValue> : IScopeFactory<TParam1, TParam2, TValue>
	{
		private readonly Func<TParam1, TParam2, TValue> _func;

		public ManualScopeFactory(Func<TParam1, TParam2, TValue> func)
		{
			_func = func;
		}

		public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2)
		{
			return new ManualScope<TValue>(_func(param1, param2));
		}
	}

	public class ManualScopeFactory<TParam1, TParam2, TParam3, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TValue>
	{
		private readonly Func<TParam1, TParam2, TParam3, TValue> _func;

		public ManualScopeFactory(Func<TParam1, TParam2, TParam3, TValue> func)
		{
			_func = func;
		}

		public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3)
		{
			return new ManualScope<TValue>(_func(param1, param2, param3));
		}
	}

	public class ManualScopeFactory<TParam1, TParam2, TParam3, TParam4, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TValue>
	{
		private readonly Func<TParam1, TParam2, TParam3, TParam4, TValue> _func;

		public ManualScopeFactory(Func<TParam1, TParam2, TParam3, TParam4, TValue> func)
		{
			_func = func;
		}

		public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
		{
			return new ManualScope<TValue>(_func(param1, param2, param3, param4));
		}
	}


	public class ManualScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TValue>
	{
		private readonly Func<TParam1, TParam2, TParam3, TParam4, TParam5, TValue> _func;

		public ManualScopeFactory(Func<TParam1, TParam2, TParam3, TParam4, TParam5, TValue> func)
		{
			_func = func;
		}

		public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
		{
			return new ManualScope<TValue>(_func(param1, param2, param3, param4, param5));
		}
	}

	public class ManualScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TValue>
	{
		private readonly Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TValue> _func;

		public ManualScopeFactory(Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TValue> func)
		{
			_func = func;
		}

		public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6)
		{
			return new ManualScope<TValue>(_func(param1, param2, param3, param4, param5, param6));
		}
	}

	public class ManualScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TValue>
	{
		private readonly Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TValue> _func;

		public ManualScopeFactory(Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TValue> func)
		{
			_func = func;
		}

		public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7)
		{
			return new ManualScope<TValue>(_func(param1, param2, param3, param4, param5, param6, param7));
		}
	}

	public class ManualScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TValue>
	{
		private readonly Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TValue> _func;

		public ManualScopeFactory(Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TValue> func)
		{
			_func = func;
		}

		public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8)
		{
			return new ManualScope<TValue>(_func(param1, param2, param3, param4, param5, param6, param7, param8));
		}
	}
}
