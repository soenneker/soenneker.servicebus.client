[![](https://img.shields.io/nuget/v/Soenneker.ServiceBus.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.ServiceBus.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.ServiceBus.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.servicebus.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.servicebus.client/actions/workflows/codeql.yml)

# Soenneker.ServiceBus.Client

A lazily initialized, dependency-injection-friendly Azure `ServiceBusClient`.

## Installation

```bash
dotnet add package Soenneker.ServiceBus.Client
```

## Configuration

Provide the Service Bus connection string at `Azure:ServiceBus:ConnectionString`:

```json
{
  "Azure": {
    "ServiceBus": {
      "ConnectionString": "Endpoint=sb://..."
    }
  }
}
```

Store the connection string in a protected configuration provider. The credential needs the data-plane permissions required by the senders, receivers, or processors created from the client.

## Registration

Use a singleton for the normal Azure SDK client reuse model:

```csharp
using Soenneker.ServiceBus.Client.Registrars;

services.AddServiceBusClientUtilAsSingleton();
```

`AddServiceBusClientUtilAsScoped()` creates one utility—and therefore one lazily created `ServiceBusClient`—per DI scope. Use it only when that isolation is intentional.

## Usage

Inject `IServiceBusClientUtil`, get the shared client, and create Azure SDK child clients from it:

```csharp
using Azure.Messaging.ServiceBus;
using Soenneker.ServiceBus.Client.Abstract;

public sealed class OrderPublisher(IServiceBusClientUtil clientUtil)
{
    public async Task Send(string json, CancellationToken cancellationToken)
    {
        ServiceBusClient client = await clientUtil.Get(cancellationToken);

        await using ServiceBusSender sender = client.CreateSender("orders");

        var message = new ServiceBusMessage(BinaryData.FromString(json))
        {
            ContentType = "application/json"
        };

        await sender.SendMessageAsync(message, cancellationToken);
    }
}
```

The utility only creates and owns the top-level `ServiceBusClient`. It does not cache senders, receivers, sessions, or processors.

Do not dispose the client returned by `Get`; the utility and DI container own it. Dispose child clients you create, such as `ServiceBusSender`, `ServiceBusReceiver`, and `ServiceBusProcessor`, according to the Azure SDK lifecycle for your application.

The client is initialized on the first `Get` call and reused for the utility's lifetime. Cancellation can stop initialization while it is pending; it does not create a separate client for that caller.
