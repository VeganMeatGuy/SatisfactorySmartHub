using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Infrastructure.Persistance;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.StaticRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Services;

internal sealed class RepositoryService(IServiceProvider serviceProvider) : IRepositoryService
{
    private readonly Lazy<StaticRecipeRepository> _lazystaticRecipeRepository = new();
    private readonly Lazy<ItemRepository> _lazyItemRepository = new();
    private readonly Lazy<CorporationRepository> _lazyCorporationRepository = new(() => new(serviceProvider));
    private readonly Lazy<BranchRepository> _lazyBranchRepository = new(() => new(serviceProvider));

    public IRecipeRepository StaticRecipeRepository => _lazystaticRecipeRepository.Value;

    public IItemRepository ItemRepository
        => _lazyItemRepository.Value;

    public ICorporationRepository CorporationRepository
    => _lazyCorporationRepository.Value;

    public IBranchRepository BranchRepository
        => _lazyBranchRepository.Value;
}
