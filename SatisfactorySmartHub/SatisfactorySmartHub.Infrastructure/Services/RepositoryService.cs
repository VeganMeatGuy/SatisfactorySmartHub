using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories;

namespace SatisfactorySmartHub.Infrastructure.Services;

internal sealed class RepositoryService(IServiceProvider serviceProvider) : IRepositoryService
{
    private readonly Lazy<CorporationRepository> _lazyCorporationRepository = new(() => new(serviceProvider));
    private readonly Lazy<BranchRepository> _lazyBranchRepository = new(() => new(serviceProvider));
    private readonly Lazy<ProcessStepRepository> _lazyProcessStepRepository = new(() => new(serviceProvider));
    private readonly Lazy<RecipeRepository> _lazyRecipeRepository = new(() => new(serviceProvider));

    public ICorporationRepository CorporationRepository
        => _lazyCorporationRepository.Value;

    public IBranchRepository BranchRepository
        => _lazyBranchRepository.Value;

    public IProcessStepRepository ProcessStepRepository
        => _lazyProcessStepRepository.Value;
    public IRecipeRepository RecipeRepository
        => _lazyRecipeRepository.Value;
}
