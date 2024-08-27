using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;

/// <summary>
/// The recipe repository interface.
/// </summary>
public interface IRecipeRepository
{
    /// <summary>
    /// Returns all entries of the <see cref="RecipeModel"/> entities.
    /// </summary>
    /// <returns><see cref="ICollection{RecipeModel}"/></returns>
    ICollection<RecipeModel> GetAll();
}
