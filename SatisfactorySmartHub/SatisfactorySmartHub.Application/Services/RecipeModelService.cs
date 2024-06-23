using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Services;

internal class RecipeModelService(IRepositoryService repositoryService)
{
    //private ICollection<RecipeModel> _recipes = repositoryService.RecipeList;

    public decimal GetNormalizedPowerConsumtion(RecipeModel recipe)
    {
        decimal productAmount = recipe.MainProduct.Amount;
        decimal machinePowerConsumption = recipe.Machine.PowerConsumption;

        decimal result = 100 / productAmount * machinePowerConsumption;

        return Math.Round(result, 4);
    }

    public ICollection<RecipeModel> GetMainRecipes(ItemModel model)
    {
        return repositoryService.RecipeModelRepository.GetAll().Where(x => x.MainProduct.Item.Name == model.Name).ToList();
    }

    //public ICollection<RecipeModel> UsedRecipes
    //{
    //    get => _recipes;
    //    set => _recipes = value;
    //}

}
