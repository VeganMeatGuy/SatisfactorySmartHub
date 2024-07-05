using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SatisfactorySmartHub.Presentation.Installer;
using SatisfactorySmartHub.Infrastructure.Installer;
using SatisfactorySmartHub.Application.Installer;

namespace SatisfactorySmartHub.Extensions
{
    internal static class ServiceCollectionExtension
    {
        internal static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddApplicationServices();
            services.AddInfrastructureServices();
            services.AddPresentationServices();

            return services;
        }
    }
}
