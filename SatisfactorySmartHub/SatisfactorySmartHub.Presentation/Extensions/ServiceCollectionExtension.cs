using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SatisfactorySmartHub.Presentation.Dialogs;
using SatisfactorySmartHub.Presentation.Windows;

namespace SatisfactorySmartHub.Presentation.Extensions;

internal static class ServiceCollectionExtension
{
    /// <summary>
    /// Adds the windows forms to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddApp(this IServiceCollection services)
    {
        services.TryAddSingleton<App>();

        return services;
    }

    /// <summary>
    /// Adds the windows to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddWindows(this IServiceCollection services)
    {
        services.TryAddSingleton<MainWindow>();
        return services;
    }


    /// <summary>
    /// Adds the windows to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddDialogs(this IServiceCollection services)
    {
        services.TryAddTransient<SelectRecipeDialog>();
        return services;
    }
}
