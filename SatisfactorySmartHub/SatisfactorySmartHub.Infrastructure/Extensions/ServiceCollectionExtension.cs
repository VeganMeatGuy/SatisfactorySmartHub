using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
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
}
