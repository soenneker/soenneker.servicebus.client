using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Soenneker.ServiceBus.Client.Abstract;

/// <summary>
/// Provides lazy access to an Azure Service Bus client configured from <c>Azure:ServiceBus:ConnectionString</c>.
/// </summary>
public interface IServiceBusClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the lazily initialized client. The returned client is owned by this service and should not be disposed by the caller.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested service Bus Client.</returns>
    [Pure]
    ValueTask<ServiceBusClient> Get(CancellationToken cancellationToken = default);
}
