namespace Dependable.Abstractions
{
	public interface IScopeFactory<out TValue>
	{
		IScope<TValue> CreateScope();
	}

	public interface IScopeFactory<in TParam1, out TValue>
	{
		IScope<TValue> CreateScope(TParam1 param1);
	}

	public interface IScopeFactory<in TParam1, in TParam2, out TValue>
	{
		IScope<TValue> CreateScope(TParam1 param1, TParam2 param2);
	}

	public interface IScopeFactory<in TParam1, in TParam2, in TParam3, out TValue>
	{
		IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3);
	}

	public interface IScopeFactory<in TParam1, in TParam2, in TParam3, in TParam4, out TValue>
	{
		IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);
	}

	public interface IScopeFactory<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, out TValue>
	{
		IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
	}

	public interface IScopeFactory<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, out TValue>
	{
		IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);
	}

	public interface IScopeFactory<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, out TValue>
	{
		IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);
	}

	public interface IScopeFactory<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TValue>
	{
		IScope<TValue> CreateScope(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);
	}
}