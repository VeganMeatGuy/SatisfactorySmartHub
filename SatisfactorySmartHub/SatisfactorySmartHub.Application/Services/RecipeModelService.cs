namespace SatisfactorySmartHub.Application.Services;

internal class RecipeModelService
{
    private ICollection<RecipeModel> _recipes = Recipes.RecipeList;

    public decimal GetNormalizedPowerConsumtion(RecipeModel recipe)
    {
        decimal productAmount = recipe.MainProduct.Amount;
        decimal machinePowerConsumption = recipe.Machine.PowerConsumption;

        decimal result = 100 / productAmount * machinePowerConsumption;

        return Math.Round(result, 4);
    }

    public ICollection<RecipeModel> GetMainRecipes(ItemModel model)
    {
        return _recipes.Where(x => x.MainProduct.Item.Name == model.Name).ToList();
    }

    public ICollection<RecipeModel> UsedRecipes
    {
        get => _recipes;
        set => _recipes = value;
    }
}
