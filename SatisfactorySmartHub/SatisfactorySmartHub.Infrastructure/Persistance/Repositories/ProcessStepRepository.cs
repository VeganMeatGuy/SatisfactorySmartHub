using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories;

internal class ProcessStepRepository(IServiceProvider serviceProvider) : IdentityRepository<ProcessStep>(serviceProvider), IProcessStepRepository
{
}
