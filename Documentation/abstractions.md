### IScopeFactory

#### Purpose

The `IScopeFactory` classes provide the ability to indicate to your IOC container that you want to create a Scope of work, without depending on any specific IOC container, or even using an IOC container at all.

It is the job of the specific implementation and the configuration of the IOC container to decide what will happen when a scope is created. A common implementation would be to create unique instances of certain classes for each scope, and to dispose of all disposable objects created within the scope once the scope is ended.

#### Usage

`IScopeFactory` is similiar to a Func. It declares a `CreateScope` method which returns an `IScope<TValue>`. The Dependable.Abstractions package defines `IScopeFactory` interfaces which take up to 8 parameters in CreateScope.

The IScopeFactory should be injected via a constructor. For example:

```csharp
public class C
{
    private readonly IScopeFactory<string, int, IServerConnection> _serverConnectionFactory;
    public C(IScopeFactory<string, int, IServerConnection> serverConnectionFactory)
    {
        _serverConnectionFactory = serverConnectionFactory
    }
}
```

Then a scope can be created by calling CreateScope:

```csharp
public CallServer(Request request)
{
    using(var scope = _serverConnectionFactory.CreateScope(request.Host, request.Port))
    {
        return scope.Value.Query(request.Query);
    }
}
```