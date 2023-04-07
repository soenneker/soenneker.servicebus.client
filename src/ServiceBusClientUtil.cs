using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
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
            var serviceBusConnString = config.GetValue<string>("Azure:ServiceBus:ConnectionString");

            if (serviceBusConnString == null)
                throw new Exception("Azure:ServiceBus:ConnectionString is required");

            var client = new ServiceBusClient(serviceBusConnString);

            return client;
        });
    }

    public ValueTask<ServiceBusClient> GetClient()
    {
        return _client.Get();
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