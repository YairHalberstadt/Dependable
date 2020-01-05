### Purpose

This library is used for manually creating instances of `IScopeFactory` without usage of an IOC.

This is useful for testing purposes.

#### Behaviour

The `ManualScopeFactory` simply wraps a `Func`. It also disposes of the `Value` when the scope is disposed (assuming the value implements `IDisposable`).

#### Usage

Create a `ManualScopeFactory` straight from a func and inject it directly.

```csharp
var scopeFactory = new ManualScopeFactory<string, int, Client>((host, port) => new Client(host, port));

var c = new C(scopeFactory);
```