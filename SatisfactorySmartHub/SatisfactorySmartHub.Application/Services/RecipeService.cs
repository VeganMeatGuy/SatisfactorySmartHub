using SatisfactorySmartHub.Application.DataTranferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Services;

/// <summary>
/// The recipe service class.
/// </summary>
internal sealed class RecipeService(IRepositoryService repositoryService) : IRecipeService
{
    public ICollection<RecipeModel> GetAllRecipes()
        => throw new NotImplementedException();
    //    => repositoryService.StaticRecipeRepository.GetAll();

    public IEnumerable<IRecipeDto> GetRecipes()
    {
        try
        {
            List<RecipeDto> result = new List<RecipeDto>();
            var repoResult = repositoryService.RecipeRepository.GetAll();

            foreach (Recipe recipe in repoResult)
                result.Add(RecipeDto.CreateFromEntity(recipe));
            return result;
        }
        catch
        {
            return new List<RecipeDto>();
        }
    }
}
