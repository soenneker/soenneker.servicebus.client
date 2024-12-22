using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.ServiceBus.Client.Abstract;

namespace Soenneker.ServiceBus.Client.Registrars;

/// <summary>
/// A utility library for Azure Service Bus client accessibility
/// </summary>
public static class ServiceBusClientUtilRegistrar
{
    public static void AddServiceBusClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusClientUtil, ServiceBusClientUtil>();
    }

    public static void AddServiceBusClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IServiceBusClientUtil, ServiceBusClientUtil>();
    }
}