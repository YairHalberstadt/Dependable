using Autofac;
using Dependable.Abstractions;

namespace Dependable.Implementations.Autofac
{
	internal static class AutofacImpl
	{
		internal class AutofacScope<T> : IScope<T>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScope(ILifetimeScope lifetimeScope)
			{
				Value = lifetimeScope.Resolve<T>();
				_lifetimeScope = lifetimeScope;
			}

			public T Value { get; }

			public void Dispose()
			{
				_lifetimeScope.Dispose();
			}
		}

		internal class AutofacScopeFactory<TValue> : IScopeFactory<TValue>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScopeFactory(ILifetimeScope lifetimeScope)
			{
				_lifetimeScope = lifetimeScope;
			}

			public IScope<TValue> CreateScope()
			{
				return Scope<TValue>(_lifetimeScope.BeginLifetimeScope());
			}
		}

		internal class AutofacScopeFactory<TParam1, TValue> : IScopeFactory<TParam1, TValue>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScopeFactory(ILifetimeScope lifetimeScope)
			{
				_lifetimeScope = lifetimeScope;
			}

			public IScope<TValue> CreateScope(TParam1 param1)
			{
				return Scope<TValue>(CreateChildScopeWith(_lifetimeScope, param1));
			}
		}

		internal class AutofacScopeFactory<TParam1, TParam2, TValue> : IScopeFactory<TParam1, TParam2, TValue>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScopeFactory(ILifetimeScope lifetimeScope)
			{
				_lifetimeScope = lifetimeScope;
			}

			public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2)
			{
				var cs = CreateChildScopeWith(_lifetimeScope, param1, param2);
				return Scope<TValue>(cs);
			}
		}

		internal class AutofacScopeFactory<TParam1, TParam2, TParam3, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TValue>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScopeFactory(ILifetimeScope lifetimeScope)
			{
				_lifetimeScope = lifetimeScope;
			}

			public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3)
			{
				var cs = CreateChildScopeWith(_lifetimeScope, param1, param2, param3);
				return Scope<TValue>(cs);
			}
		}

		internal class AutofacScopeFactory<TParam1, TParam2, TParam3, TParam4, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TValue>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScopeFactory(ILifetimeScope lifetimeScope)
			{
				_lifetimeScope = lifetimeScope;
			}

			public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)
			{
				var cs = CreateChildScopeWith(_lifetimeScope, param1, param2, param3, param4);
				return Scope<TValue>(cs);
			}
		}

		internal class AutofacScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TValue>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScopeFactory(ILifetimeScope lifetimeScope)
			{
				_lifetimeScope = lifetimeScope;
			}

			public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5)
			{
				var cs = CreateChildScopeWith(_lifetimeScope, param1, param2, param3, param4, param5);
				return Scope<TValue>(cs);
			}
		}

		internal class AutofacScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TValue>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScopeFactory(ILifetimeScope lifetimeScope)
			{
				_lifetimeScope = lifetimeScope;
			}

			public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6)
			{
				var cs = CreateChildScopeWith(_lifetimeScope, param1, param2, param3, param4, param5, param6);
				return Scope<TValue>(cs);
			}
		}

		internal class AutofacScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TValue>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScopeFactory(ILifetimeScope lifetimeScope)
			{
				_lifetimeScope = lifetimeScope;
			}

			public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7)
			{
				var cs = CreateChildScopeWith(_lifetimeScope, param1, param2, param3, param4, param5, param6, param7);
				return Scope<TValue>(cs);
			}
		}

		internal class AutofacScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TValue> : IScopeFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TValue>
		{
			private readonly ILifetimeScope _lifetimeScope;

			public AutofacScopeFactory(ILifetimeScope lifetimeScope)
			{
				_lifetimeScope = lifetimeScope;
			}

			public IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8)
			{
				var cs = CreateChildScopeWith(_lifetimeScope, param1, param2, param3, param4, param5, param6, param7, param8);
				return Scope<TValue>(cs);
			}
		}

		private static ILifetimeScope CreateChildScopeWith<T>(ILifetimeScope lifetimeScope, T value)
		{
			return lifetimeScope.BeginLifetimeScope(Tag.GetTag<T>(), c => c.Register(_ => value));
		}

		private static ILifetimeScope CreateChildScopeWith<T1, T2>(ILifetimeScope lifetimeScope, T1 value1, T2 value2)
		{
			return lifetimeScope.BeginLifetimeScope(Tag.GetTag<T1, T2>(), c => { c.Register(_ => value1); c.Register(_ => value2); });
		}

		private static ILifetimeScope CreateChildScopeWith<T1, T2, T3>(ILifetimeScope lifetimeScope, T1 value1, T2 value2, T3 value3)
		{
			return lifetimeScope.BeginLifetimeScope(Tag.GetTag<T1, T2, T3>(), c => { c.Register(_ => value1); c.Register(_ => value2); c.Register(_ => value3); });
		}

		private static ILifetimeScope CreateChildScopeWith<T1, T2, T3, T4>(ILifetimeScope lifetimeScope, T1 value1, T2 value2, T3 value3, T4 value4)
		{
			return lifetimeScope.BeginLifetimeScope(Tag.GetTag<T1, T2, T3, T4>(), c => { c.Register(_ => value1); c.Register(_ => value2); c.Register(_ => value3); c.Register(_ => value4); });
		}

		private static ILifetimeScope CreateChildScopeWith<T1, T2, T3, T4, T5>(ILifetimeScope lifetimeScope, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
		{
			return lifetimeScope.BeginLifetimeScope(Tag.GetTag<T1, T2, T3, T4, T5>(), c => { c.Register(_ => value1); c.Register(_ => value2); c.Register(_ => value3); c.Register(_ => value4); c.Register(_ => value5); });
		}

		private static ILifetimeScope CreateChildScopeWith<T1, T2, T3, T4, T5, T6>(ILifetimeScope lifetimeScope, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
		{
			return lifetimeScope.BeginLifetimeScope(Tag.GetTag<T1, T2, T3, T4, T5, T6>(), c => { c.Register(_ => value1); c.Register(_ => value2); c.Register(_ => value3); c.Register(_ => value4); c.Register(_ => value5); c.Register(_ => value6); });
		}

		private static ILifetimeScope CreateChildScopeWith<T1, T2, T3, T4, T5, T6, T7>(ILifetimeScope lifetimeScope, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
		{
			return lifetimeScope.BeginLifetimeScope(Tag.GetTag<T1, T2, T3, T4, T5, T6, T7>(), c => { c.Register(_ => value1); c.Register(_ => value2); c.Register(_ => value3); c.Register(_ => value4); c.Register(_ => value5); c.Register(_ => value6); c.Register(_ => value7); });
		}

		private static ILifetimeScope CreateChildScopeWith<T1, T2, T3, T4, T5, T6, T7, T8>(ILifetimeScope lifetimeScope, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
		{
			return lifetimeScope.BeginLifetimeScope(Tag.GetTag<T1, T2, T3, T4, T5, T6, T7, T8>(), c => { c.Register(_ => value1); c.Register(_ => value2); c.Register(_ => value3); c.Register(_ => value4); c.Register(_ => value5); c.Register(_ => value6); c.Register(_ => value7); c.Register(_ => value8); });
		}

		private static IScope<T> Scope<T>(ILifetimeScope lifetimeScope)
		{
			return new AutofacScope<T>(lifetimeScope);
		}
	}
}
