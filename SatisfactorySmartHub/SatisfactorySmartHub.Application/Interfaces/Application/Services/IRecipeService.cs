using SatisfactorySmartHub.Application.DataTranferObjects;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The recipe service interface.
/// </summary>
public interface IRecipeService
{
    IEnumerable<RecipeDto> GetRecipes();
}
