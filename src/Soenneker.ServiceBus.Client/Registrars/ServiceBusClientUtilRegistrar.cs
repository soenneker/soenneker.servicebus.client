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
    /// Registers Service Bus Client Util with a singleton lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddServiceBusClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IServiceBusClientUtil, ServiceBusClientUtil>();

        return services;
    }

    /// <summary>
    /// Registers Service Bus Client Util with a scoped lifetime.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddServiceBusClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IServiceBusClientUtil, ServiceBusClientUtil>();

        return services;
    }
}
