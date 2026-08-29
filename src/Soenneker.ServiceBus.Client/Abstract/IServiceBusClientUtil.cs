using System;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Soenneker.ServiceBus.Client.Abstract;

/// <summary>
/// A utility library for Azure Service Bus client accessibility <para/>
/// Singleton IoC
/// </summary>
public interface IServiceBusClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Lets try to pass all service bus traffic over this one client
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested service Bus Client.</returns>
    [Pure]
    ValueTask<ServiceBusClient> Get(CancellationToken cancellationToken = default);
}
