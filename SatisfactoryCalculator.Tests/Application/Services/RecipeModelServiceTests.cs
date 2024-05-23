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
        Tuple<RecipeModel, decimal> bla = new(Recipes.IronIngot, 27);
        List<Tuple<RecipeModel, decimal>> TestData =
            [
                new(Recipes.IronIngot, 13.3333m),
                new(Recipes.IronAlloyIngot, 32),
                new(Recipes.PureIronIngot, 46.1538m)
            ];

        foreach (Tuple<RecipeModel, decimal> DataSet in TestData)
        {
            decimal calculatedPowerConsumption = recipeService.GetNormalizedPowerConsumtion(DataSet.Item1);
            Assert.AreEqual(DataSet.Item2, calculatedPowerConsumption);
        }
    }

    [TestMethod]
    public void RecipeModelService_GetRecipes()
    {
        RecipeModelService recipeService = new();
        ICollection<RecipeModel> results = recipeService.GetRecipes(Items.IronIngot);

        bool containsIronIngot = results.Contains(Recipes.IronIngot);
        bool containsIronAlloyIngot = results.Contains(Recipes.IronAlloyIngot);
        bool containsPureIronIngot = results.Contains(Recipes.PureIronIngot);
        bool containsOtherRecipes = results.Any(x => x.MainProduct.Item.Name != Items.IronIngot.Name);

        Assert.IsTrue(containsIronIngot);
        Assert.IsTrue(containsIronAlloyIngot);
        Assert.IsTrue(containsPureIronIngot);
        Assert.IsFalse(containsOtherRecipes);
    }
}
