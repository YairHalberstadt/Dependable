# Dependable

Dependency Injection used correctly

## Aim

One of the most important principles of IOC Containers is that they shouldn't affect the code at all. Their usage should be entirely outside the scope of your project.

At the very top level you should build your container, and then there should be a single call to Resolve in your application.

That way, you are not tied to any specific IOC container, or even a container at all. You can just inject all your dependencies manually if you want to.

Unfortunately this becomes difficult to do if you want to use anything more complex, like scopes, or similiar, since IOC containers often don't expose suitable abstractions to use these complex features without exposing your code to the particular IOC container your using.

Dependable aims to provide suitable abstractions for doing this, as well as implementations for Autofac (the IOC container I use). However implementations for alternative containers are welcomed.