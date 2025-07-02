using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Configuration;
using Soenneker.ServiceBus.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ServiceBus.Client;

///<inheritdoc cref="IServiceBusClientUtil"/>
public sealed class ServiceBusClientUtil : IServiceBusClientUtil
{
    private readonly AsyncSingleton<ServiceBusClient> _client;

    public ServiceBusClientUtil(IConfiguration config, ILogger<ServiceBusClientUtil> logger)
    {
        _client = new AsyncSingleton<ServiceBusClient>(() =>
        {
            var serviceBusConnString = config.GetValueStrict<string>("Azure:ServiceBus:ConnectionString");

            logger.LogDebug("Initializing Service Bus client...");

            return new ServiceBusClient(serviceBusConnString);
        });
    }

    public ValueTask<ServiceBusClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }

    public void Dispose()
    {
        _client.Dispose();
    }
}