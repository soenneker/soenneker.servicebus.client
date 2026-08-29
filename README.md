[![](https://img.shields.io/nuget/v/Soenneker.ServiceBus.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.ServiceBus.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.client/actions/workflows/codeql.yml)

# Soenneker.ServiceBus.Client

A utility library for Azure Service Bus client accessibility Singleton IoC.

## Install

```bash
dotnet add package Soenneker.ServiceBus.Client
```

## Quick start

```csharp
using Soenneker.ServiceBus.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddServiceBusClientUtilAsSingleton();
```

Registers Service Bus Client Util with a singleton lifetime.

## What you get

- `IServiceBusClientUtil` — A utility library for Azure Service Bus client accessibility Singleton IoC.
- `ServiceBusClientUtilRegistrar` — A utility library for Azure Service Bus client accessibility.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IServiceBusClientUtil.Get(cancellationToken)` | Lets try to pass all service bus traffic over this one client. | A task whose result is the requested service Bus Client. |
| `ServiceBusClientUtilRegistrar.AddServiceBusClientUtilAsSingleton(services)` | Registers Service Bus Client Util with a singleton lifetime. | The same service collection, so additional registrations can be chained. |
| `ServiceBusClientUtilRegistrar.AddServiceBusClientUtilAsScoped(services)` | Registers Service Bus Client Util with a scoped lifetime. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
