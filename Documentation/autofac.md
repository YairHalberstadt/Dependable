## Usage

Register `Dependable.Implementations.Autofac.Module` with your Autofac container.

```csharp
builder.RegisterModule<Dependable.Implementations.Autofac.Module>();
```

This module registers implementations of IScopeFactory. They will be automatically injected when you resolve a component which requires an IScopeFactory.

### Behaviour

Every time CreateScope is called, it will create a new `ILifetimeScope`. This means that any registration registered as `InstancePerLifetimeScope` will be unique for each Scope.

Any disposable object that is created under the scope will be disposed when the scope is disposed.

#### Parameters

Any parameters passed to CreateScope will be registered with the created `ILifetimeScope`. This means that they will be available whenever resolving any instance within the scope.

For example the following will work:

```csharp
class C
{
    public C(string s, D d, Func<D> dFunc)
    {
        dFunc()
    }
}

class D
{
    public D(string s){}
}
...
var builder = new ContainerBuilder();
builder.RegisterModule<Dependable.Implementations.Autofac.Module>()
builder.RegisterType<C>().InstancePerLifetimeScope();
builder.RegisterType<D>().InstancePerDependency();
var container = builder.Build();
var scopeFactory = container.Resolve<IScopeFactory<string, C>>();
Assert.NotNull(scopeFactory.CreateScope("some string"));
```

#### Tags and InstancePerMatchingLifetimeScope

You can register a type as `InstancePerMatchingLifetimeScope` with a tag created using `Dependable.Implementations.Autofac.Tag`. You can pass up to 8 type parameters to Tag.CreateTag.

An instance of `IScopeFactory` that has a `TParam` of the same type as any of the type parameters as the `Tag` will create a new instance of the type.

This way you can control when a scope will create a new instance of an object. You indicate that you want to create a new instance any time a new instance of a particular `Type` is provided as a parameter to `CreateScope`.

For example:

```csharp
builder.RegisterType<Client>.AsInstancePerMatchingLifetimeScope(Tag.CreateTag<Uri>());
...

class C
{
    public readonly ScopeFactory<Uri, D> 
    public C(IScopeFactory<Uri, D> scopeFactory)
        => _scopeFactory = scopeFactory;

    public M(Uri uri, object obj)
    {
        using(var scope = _scopeFactory.CreateScope(uri)) //this will create a new instance of `Client`
        {
            scope.Value.M(obj);
        }
    }
}

class D
{
    public readonly ScopeFactory<object, Client> 
    public D(IScopeFactory<object, Client> scopeFactory)
        => _scopeFactory = scopeFactory;

    public M(object obj)
    {
        using(var scope = _scopeFactory.CreateScope(obj)) //this will not create a new instance of `Client`
        {
            scope.Value.Execute();
        }
    }
}
```