using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;

/// <summary>
/// The repository service interface.
/// </summary>
public interface IRepositoryService
{
    ICorporationRepository CorporationRepository { get; }
    IBranchRepository BranchRepository { get; }
    IProcessStepRepository ProcessStepRepository { get; }
    IRecipeRepository RecipeRepository { get; }
}
