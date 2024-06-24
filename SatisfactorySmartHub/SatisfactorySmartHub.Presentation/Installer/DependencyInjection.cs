using Microsoft.Extensions.DependencyInjection;
using SatisfactorySmartHub.Presentation.Extensions;

namespace SatisfactorySmartHub.Presentation.Installer;

public static class DependencyInjection
{
    private static IServiceProvider? s_services;

    /// <summary>
    /// The service provider property.
    /// </summary>
    public static IServiceProvider Services
        => s_services ??= RegisterServices();

    /// <summary>
    /// Adds the presentation services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        _ = services.AddApp();
        _ = services.AddWindows();
        _ = services.AddWindowModels();
        _ = services.AddViewModels();
        _ = services.AddNavigation();

        return services;
    }

    private static IServiceProvider RegisterServices()
    {
        ServiceCollection services = new();

        services.AddPresentationServices();

        return services.BuildServiceProvider();
    }
}
