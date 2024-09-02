using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;

/// <summary>
/// The repository service interface.
/// </summary>
public interface IRepositoryService
{
    /// <summary>
    /// The static recipe repository instance.
    /// </summary>
    IRecipeRepository StaticRecipeRepository { get; }
}
