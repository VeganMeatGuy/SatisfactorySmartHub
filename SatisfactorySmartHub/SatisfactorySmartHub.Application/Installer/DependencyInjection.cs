using Microsoft.Extensions.DependencyInjection;
using SatisfactorySmartHub.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Installer;

/// <summary>
/// The application dependency injection class.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds the application services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to enrich.</param>
    /// <returns>The enriched service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.RegisterServices();

        return services;
    }
}
