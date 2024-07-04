using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Soenneker.Extensions.Configuration;
using Soenneker.ServiceBus.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ServiceBus.Client;

///<inheritdoc cref="IServiceBusClientUtil"/>
public class ServiceBusClientUtil : IServiceBusClientUtil
{
    private readonly AsyncSingleton<ServiceBusClient> _client;

    public ServiceBusClientUtil(IConfiguration config)
    {
        _client = new AsyncSingleton<ServiceBusClient>(() =>
        {
            var serviceBusConnString = config.GetValueStrict<string>("Azure:ServiceBus:ConnectionString");

            var client = new ServiceBusClient(serviceBusConnString);

            return client;
        });
    }

    public ValueTask<ServiceBusClient> GetClient(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _client.DisposeAsync();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
    }
}