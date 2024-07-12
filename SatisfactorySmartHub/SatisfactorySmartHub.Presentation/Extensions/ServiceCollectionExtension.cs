using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SatisfactorySmartHub.Presentation.Common;
using SatisfactorySmartHub.Presentation.Common.Interfaces;
using SatisfactorySmartHub.Presentation.Interfaces.Services;
using SatisfactorySmartHub.Presentation.Services;
using SatisfactorySmartHub.Presentation.ViewModels;
using SatisfactorySmartHub.Presentation.ViewModels.Base;
using SatisfactorySmartHub.Presentation.WindowModels;
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
    /// Adds the windowmodels to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddWindowModels(this IServiceCollection services)
    {
        services.TryAddTransient<MainWindowModel>();
        return services;
    }

    /// <summary>
    /// Adds the viewmodels to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.TryAddTransient<HubViewModel>();
        services.TryAddTransient<AdminViewModel>();
        services.TryAddTransient<CorporationViewModel>();
        return services;
    }

    /// <summary>
    /// Adds the navigation to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddNavigation(this IServiceCollection services)
    {
        services.TryAddTransient<INavigationHelper, NavigationHelper>();
        services.TryAddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));
        return services;
    }

    /// <summary>
    /// Adds utilities to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddUtilities(this IServiceCollection services)
    {
        services.TryAddSingleton<ICachingService, CachingService>();
        return services;
    }
}
