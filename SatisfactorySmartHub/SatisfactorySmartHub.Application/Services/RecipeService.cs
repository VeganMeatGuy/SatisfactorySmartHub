using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.Services;

/// <summary>
/// The recipe service class.
/// </summary>
internal sealed class RecipeService(IRepositoryService repositoryService) : IRecipeService
{
    public IEnumerable<RecipeDto> GetRecipes()
    {
        try
        {
            var RecipeRepoResult = repositoryService.RecipeRepository.GetAllEager();
            List<RecipeDto> result = new List<RecipeDto>();
            foreach (Recipe recipe in RecipeRepoResult)
            {
                result.Add(RecipeDto.CreateFromEntity(recipe));
            }
            return result;
        }
        catch
        {
            return new List<RecipeDto>();
        }
    }
}
