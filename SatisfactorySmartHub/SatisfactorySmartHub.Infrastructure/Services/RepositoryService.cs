using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Infrastructure.Persistance;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.StaticRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Services;

internal sealed class RepositoryService : IRepositoryService
{
    private readonly Lazy<StaticRecipeRepository> _lazystaticRecipeRepository = new();

    public IRecipeRepository StaticRecipeRepository => _lazystaticRecipeRepository.Value;
}
