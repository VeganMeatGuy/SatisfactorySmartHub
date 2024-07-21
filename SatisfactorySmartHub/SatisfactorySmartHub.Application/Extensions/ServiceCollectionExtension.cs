using Microsoft.Extensions.DependencyInjection;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Services;

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
        services.AddSingleton<ICorporationService, CorporationService>();

        return services;
    }
}
