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
    private readonly ILogger<ServiceBusClientUtil> _logger;
    private readonly string _serviceBusConnString;

    private readonly AsyncSingleton<ServiceBusClient> _client;

    public ServiceBusClientUtil(IConfiguration config, ILogger<ServiceBusClientUtil> logger)
    {
        _logger = logger;
        _serviceBusConnString = config.GetValueStrict<string>("Azure:ServiceBus:ConnectionString");

        // No closure: method group
        _client = new AsyncSingleton<ServiceBusClient>(CreateClient);
    }

    private ValueTask<ServiceBusClient> CreateClient(CancellationToken token)
    {
        _logger.LogDebug("Initializing Service Bus client...");
        return ValueTask.FromResult(new ServiceBusClient(_serviceBusConnString));
    }

    public ValueTask<ServiceBusClient> Get(CancellationToken cancellationToken = default) =>
        _client.Get(cancellationToken);

    public ValueTask DisposeAsync() => _client.DisposeAsync();

    public void Dispose() => _client.Dispose();
}