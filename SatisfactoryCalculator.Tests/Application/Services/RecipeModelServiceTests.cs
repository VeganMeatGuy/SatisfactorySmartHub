using SatisfactoryCalculator.Application.Services;
using SatisfactoryCalculator.Domain.Models;
using SatisfactoryCalculator.Infrastructure.Persistence.StaticDataModel;

namespace SatisfactoryCalculator.Tests.Application.Services;

[TestClass]
public class RecipeModelServiceTests
{
    [TestMethod]
    public void RecipeModelService_GetNormalizedPowerConsumtion()
    {
        //arrange
        RecipeModelService recipeService = new();
        ICollection<RecipeModel> usedRecipes = new HashSet<RecipeModel>();
        usedRecipes.Add(Recipes.IronIngot);
        usedRecipes.Add(Recipes.IronAlloyIngot);
        usedRecipes.Add(Recipes.PureIronIngot);
        recipeService.UsedRecipes = usedRecipes;

        List<Tuple<RecipeModel, decimal>> TestData =
            [
                new(Recipes.IronIngot, 13.3333m),
                new(Recipes.IronAlloyIngot, 32),
                new(Recipes.PureIronIngot, 46.1538m),
                new(Recipes.CokeSteelIngot, 16m)
            ];

        foreach (Tuple<RecipeModel, decimal> DataSet in TestData)
        {
            decimal calculatedPowerConsumption = recipeService.GetNormalizedPowerConsumtion(DataSet.Item1);
            Assert.AreEqual(DataSet.Item2, calculatedPowerConsumption);
        }
    }

    [TestMethod]
    public void RecipeModelService_GetMainRecipes()
    {
        //arrange
        RecipeModelService recipeService = new();
        ICollection<RecipeModel> usedRecipes = new HashSet<RecipeModel>();
        usedRecipes.Add(Recipes.IronIngot);
        usedRecipes.Add(Recipes.IronAlloyIngot);
        usedRecipes.Add(Recipes.SteelBeam);
        recipeService.UsedRecipes = usedRecipes;

        //act
        ICollection<RecipeModel> results = recipeService.GetMainRecipes(Items.IronIngot);
        bool containsIronIngot = results.Contains(Recipes.IronIngot);
        bool containsIronAlloyIngot = results.Contains(Recipes.IronAlloyIngot);
        bool containsOtherRecipes = results.Any(x => x.MainProduct.Item.Name != Items.IronIngot.Name);

        //assert
        Assert.IsTrue(containsIronIngot);
        Assert.IsTrue(containsIronAlloyIngot);
        Assert.IsFalse(containsOtherRecipes);
    }
    [TestMethod]
    public void RecipeModelService_GetMainRecipes_ReturnsEmtyListWhenNoneRecipeIsAvailable()
    {
        //arrange
        RecipeModelService recipeService = new();

        //act
        ICollection<RecipeModel> results = recipeService.GetMainRecipes(Items.IronOre);

        //assert
        Assert.IsTrue(results.Count == 0);
    }
}
