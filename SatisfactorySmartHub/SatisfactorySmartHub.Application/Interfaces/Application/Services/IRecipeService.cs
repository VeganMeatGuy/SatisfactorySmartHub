using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The recipe service interface.
/// </summary>
public interface IRecipeService
{
    IEnumerable<IRecipeDto> GetRecipes();
}
