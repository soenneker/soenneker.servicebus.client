using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.ServiceBus.Client.Abstract;

namespace Soenneker.ServiceBus.Client.Registrars;

/// <summary>
/// A utility library for Azure Service Bus client accessibility
/// </summary>
public static class ServiceBusClientUtilRegistrar
{
    public static IServiceCollection AddServiceBusClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusClientUtil, ServiceBusClientUtil>();

        return services;
    }

    public static IServiceCollection AddServiceBusClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IServiceBusClientUtil, ServiceBusClientUtil>();

        return services;
    }
}