using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Common;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Infrastructure.Common;
using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;
using SatisfactorySmartHub.Infrastructure.Persistance;
using SatisfactorySmartHub.Infrastructure.Provider;
using SatisfactorySmartHub.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Extensions;

/// <summary>
/// The infrastructure service collection extensions.
/// </summary>
internal static class ServiceCollectionExtension
{
    /// <summary>
    /// Registers the repository service to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection RegisterRepositoryService(this IServiceCollection services)
    {
        services.TryAddSingleton<IRepositoryService, RepositoryService>();
        return services;
    }

    /// <summary>
    /// Adds utilities to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddUtilities(this IServiceCollection services)
    {
        services.TryAddTransient<IUserOptionsHelper, UserOptionsHelper>();
        return services;
    }

    /// <summary>
    /// Adds providers to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddProviders(this IServiceCollection services)
    {
        services.TryAddSingleton<IFileProvider, FileProvider>();
        services.TryAddSingleton<IDirectoryProvider, DirectoryProvider>();
        return services;
    }


    /// <summary>
    /// Adds providers to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.TryAddSingleton<ICorporationFileService, CorporationFileService>();
        return services;
    }

}
