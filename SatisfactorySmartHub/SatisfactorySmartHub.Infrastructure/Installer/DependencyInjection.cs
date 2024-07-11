using Microsoft.Extensions.DependencyInjection;
using SatisfactorySmartHub.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Installer;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        /// <summary>
        /// Adds the infrastructure services to the service collection.
        /// </summary>
        /// <param name="services">The service collection to enrich.</param>
        /// <returns>The enriched service collection.</returns>
        services.RegisterRepositoryService();
        services.AddUtilities();  

        return services;
    }
}
