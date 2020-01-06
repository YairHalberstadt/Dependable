# Dependable

Dependency Injection used correctly

[![Build Status](https://dev.azure.com/yairhalberstadt/Dependable/_apis/build/status/YairHalberstadt.Dependable?branchName=master)](https://dev.azure.com/yairhalberstadt/Dependable/_build/latest?definitionId=4&branchName=master)

## Packages

https://www.nuget.org/packages/Dependable.Abstractions
https://www.nuget.org/packages/Dependable.Implementations.Manual
https://www.nuget.org/packages/Dependable.Implementations.Autofac

```pm
Install-Package Dependable.Abstractions -Version 1.0.0-CI-20200105-194825
Install-Package Dependable.Implementations.Manual -Version 1.0.0-CI-20200105-194825
Install-Package Dependable.Implementations.Autofac -Version 1.0.0-CI-20200105-194825
```

## Aim

One of the most important principles of IOC Containers is that they shouldn't affect the code at all. Their usage should be entirely outside the scope of your project.

At the very top level you should build your container, and then there should be a single call to Resolve in your application.

That way, you are not tied to any specific IOC container, or even a container at all. You can just inject all your dependencies manually if you want to.

Unfortunately this becomes difficult to do if you want to use any of the more complex features of IOCs, like scopes, or similiar, since IOC containers often don't expose suitable abstractions to use these complex features without exposing your code to the particular IOC container your using.

Dependable aims to provide suitable abstractions for doing this, as well as implementations for Autofac (the IOC container I use). However implementations for alternative containers are welcomed.

## Documentation

- [Abstractions](Documentation/abstractions.md)
- [Autofac Implementation](Documentation/autofac.md)
- [Manual Implementation](Documentation/manual.md)

## Example Use Case

This works through a problem using the `Autofac` IOC container and how it can be solved using this library.

### Problem

We have a server that handles many requests simultaneaously using a unique `IRequestHandler` for each `Request`. All the various objects that are used in the process of handling a request have access to an `ILogger`. This is a problem that can easily be handled by IOC containers and standard DI techniques.

Now our requirements change, and we want the logger to prepend the `RequestId` before the rest of the log message. That means we need to inject the `RequestId` into all the loggers used whilst handling a request.

One way to do this is to have the logger accept an `ILoggerState` which provides the preamble for the log message.

```csharp
public class LoggerWithLoggerState : ILogger
{
    private readonly ILogger _impl;
    private readonly ILoggerState _loggerState;
    public LoggerWithLoggerState(ILogger impl, ILoggerState loggerState)
    {
        _impl = impl;
        _loggerState = loggerState;
    }
    public void Log(string message)
    {
        _impl.Log(_loggerState.Preamble + " " + message);
    }
}

public interface ILoggerState
{
    public string Preamble { get; }
}

public class RequestIdLoggerState : ILoggerState
{
    public RequestIdLoggerState(Guid requestId)
    {
        Preamble = requestId.ToString();
    }
    public string Preamble { get; }
}
...
builder.RegisterDecorator<LoggerWithLoggerState, ILogger>();
builder.RegisterType<RequestIdLoggerState>().As<ILoggerState>();
```

Now we need to make sure that every request has a single, unique instance of the `ILoggerState`, and that we can inject the `requestId` into that instance.

In autofac the standard way to solve this would be using LifetimeScopes:

```csharp
builder.RegisterType<RequestIdLoggerState>().As<ILoggerState>().InstancePerLifetimeScope();

public class Server
{
    private readonly ILifetimeScope _lifetimeScope;
    public Server(ILifetimeScope lifetimeScope) => _lifetimeScope = lifetimeScope;
    public void HandleRequest(Request request)
    {
        using (var scope = lifetimeScope.BeginLifetimeScope(c => c.Register(_ => request.Id));
        {
            scope.Resolve<RequestHandler>().HandleRequest(request);
        }
    }
}
```

There are at least 3 problems with this code:

1: We are injecting an `ILifetimeScope`. This is an interface defined by autofac. This will make it difficult if we don't want to depend on `Autofac`.

2: `ILifetimeScope` is a service provider, which is a well known anti-pattern. This means that we can't know which dependencies the `Server` actually requires by looking at its' constructor. This makes testing difficult, and makes it much easier to bring in dependencies we don't need.

3: We are registering a `Guid`. This is a bad idea as a lot of types might have a constructor which accepts a `Guid`, but they all require a different `Guid`. This can be solved without using this library, but I will show you a solution here for good measure.

### Solution

Lets start by solving problems 1 and 2.

First we register `Dependable.Implementations.Autofac.Module`:

```csharp
builder.RegisterModule<Dependable.Implementations.Autofac.Module>();
builder.RegisterDecorator<LoggerWithLoggerState, ILogger>();
builder.RegisterType<RequestIdLoggerState>().As<ILoggerState>().InstancePerLifetimeScope();
```

Now instead of depending on an `ILifetimeScope`, we depend on an `IScopeFactory<Guid, RequestHandler>`:

```csharp
public class Server
{
    private readonly IScopeFactory<Guid, RequestHandler> _requestHandlerFactory;
    public Server(IScopeFactory<Guid, RequestHandler> requestHandlerFactory) => _requestHandlerFactory = requestHandlerFactory;
    public void HandleRequest(Request request)
    {
        using (var scope = _requestHandlerFactory.CreateScope(request.Id));
        {
            scope.Value.HandleRequest(request);
        }
    }
}
```

As you can see this code looks extremely similiar to what we had earlier but solves the first two problems.
We rely on types defined in `Dependable.Abstractions` which doesn't depend on `Autofac`.
We explicitly state which services we need, and which parameters we intend to provide to it.
We can test this easily using the `ManualScopeFactory`s defined in `Dependable.Implementations.Manual`, which take `Func`s rather than relying on an IOC container.

As for solving the final problem?

There's more than one way to skin a cat, but this is how I would do it:

```csharp
builder.RegisterModule<Dependable.Implementations.Autofac.Module>();
builder.RegisterDecorator<LoggerWithLoggerState, ILogger>();
builder.RegisterType<RequestIdLoggerState>().As<ILoggerState>().InstancePerDependency();

public class Server
{
    private readonly IScopeFactory<ILoggerState, RequestHandler> _requestHandlerFactory;
    private readonly Func<Guid, ILoggerState> _loggerStateFactory;
    public Server(IScopeFactory<ILoggerState, RequestHandler> requestHandlerFactory, Func<Guid, ILoggerState> loggerStateFactory) 
        => (_requestHandlerFactory, _loggerStateFactory) = (requestHandlerFactory, loggerStateFactory);
    public void HandleRequest(Request request)
    {
        var loggerState = _loggerStateFactory(request.Id);
        using (var scope = _requestHandlerFactory.CreateScope(loggerState));
        {
            scope.Value.HandleRequest(request);
        }
    }
}
```

Simple! (and you can of course do exactly the same with the original, pure Autofac example).

### Tags

By default we create a new instance of our logger for every single dependency. We might want to only have a single instance for each `LoggerState`.

Registering the logger as `InstancePerLifetimeScope()` has almost the correct behaviour. It only creates a new logger when we create a new scope. Howerver it doesn't have quite the semantics we want. We don't need a new logger for every single scope. We only need one when a new `ILoggerState` is available.

The `Dependable.Implementations.Autofac.Tag` type allow us to do this. We register the logger as follows:

```csharp
builder.RegisterType<Logger>().AsInstancePerMatchingLifetimeScope(Tag.CreateTag<ILoggerState>());
```

Now a new `Logger` will be created only when a scope is created by an instance of `IScopeFactory` that accepts `ILoggerState` as a parameter.

So `IScopeFactory<string, IRequestHandler>` will not create a new `Logger`, whilst `IScopeFactory<ILoggerState, IRequestHandler>` will.

Your logger might depend on multiple dependencies, and therefore you might want to create a new `Logger` when a new instance of any of them are provided. This can be done by adding more generic parameters to `CreateTag`. For example `Tag.CreateTag<ILoggerState, TextWriter>()`.