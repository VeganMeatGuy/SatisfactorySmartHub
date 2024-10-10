using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Infrastructure.Common;
using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;
using SatisfactorySmartHub.Infrastructure.Persistance;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories;
using SatisfactorySmartHub.Infrastructure.Provider;
using SatisfactorySmartHub.Infrastructure.Services;

namespace SatisfactorySmartHub.Infrastructure.Extensions;

/// <summary>
/// The infrastructure service collection extensions.
/// </summary>
internal static class ServiceCollectionExtension
{
    internal static IServiceCollection RegisterRepositoryContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddDbContext<RepositoryContext>(optionsAction =>
        {
            optionsAction.UseSqlite(configuration.GetConnectionString("SqLiteConnection"), sqliteOptionsAction
                => sqliteOptionsAction.MigrationsAssembly("SatisfactorySmartHub"));

            if(environment.IsDevelopment())
            {
                optionsAction.EnableSensitiveDataLogging();
                optionsAction.EnableDetailedErrors();
                //optionsAction.LogTo(Console.WriteLine, LogLevel.Debug);
            }

            if (environment.IsProduction())
            {
                optionsAction.EnableDetailedErrors(false);
                optionsAction.EnableSensitiveDataLogging(false);
            }
        }, ServiceLifetime.Scoped);

        return services;
    }


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
        services.TryAddTransient<IUserDataService, UserDataService>();
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
        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.TryAddSingleton<IJsonSerializer, JsonSerializer>();
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
