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
    /// Adds service bus client util as singleton.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddServiceBusClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusClientUtil, ServiceBusClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds service bus client util as scoped.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The result of the operation.</returns>
    public static IServiceCollection AddServiceBusClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IServiceBusClientUtil, ServiceBusClientUtil>();

        return services;
    }
}