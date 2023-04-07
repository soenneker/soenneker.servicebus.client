using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.ServiceBus.Client.Abstract;

namespace Soenneker.ServiceBus.Client.Registrars;

/// <summary>
/// A utility library for Azure Service Bus client accessibility
/// </summary>
public static class ServiceBusClientUtilRegistrar
{
    /// <summary>
    /// As Singleton
    /// </summary>
    public static void AddBlobClientUtil(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusClientUtil, ServiceBusClientUtil>();
    }
}