using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Application.ViewModels;
using SatisfactorySmartHub.Application.ViewModels.Base;
using SatisfactorySmartHub.Application.WindowModels;

namespace SatisfactorySmartHub.Application.Extensions;
/// <summary>
/// The application service collection extensions.
/// </summary>
internal static class ServiceCollectionExtension
{
    /// <summary>
    /// Registers the application services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.TryAddSingleton<IItemService, ItemService>();
        services.TryAddSingleton<ICorporationService, CorporationService>();
        services.TryAddSingleton<IBranchService, BranchService>();
        services.TryAddSingleton<ICachingService, CachingService>();
        services.TryAddSingleton<IProcessStepService, ProcessStepService>();
        services.TryAddSingleton<IProductionSiteService, ProductionSiteService>();
        services.TryAddSingleton<IRecipeService, RecipeService>();

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
        services.TryAddTransient<BranchViewModel>();
        return services;
    }

    /// <summary>
    /// Adds the navigation to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddNavigation(this IServiceCollection services)
    {
        services.TryAddSingleton<INavigationService, NavigationService>();
        services.TryAddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));
        return services;
    }

}
