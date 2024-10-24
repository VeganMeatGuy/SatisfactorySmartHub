using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.Base;
using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;

/// <summary>
/// The recipe repository interface.
/// </summary>
public interface IRecipeRepository : IIdentityRepository<Recipe>
{
}
