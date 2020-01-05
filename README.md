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
