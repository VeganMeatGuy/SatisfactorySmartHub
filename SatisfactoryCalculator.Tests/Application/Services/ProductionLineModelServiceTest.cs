using SatisfactoryCalculator.Application.Services;
using SatisfactoryCalculator.Domain.Models;
using SatisfactoryCalculator.Infrastructure.Persistence.StaticDataModel;

namespace SatisfactoryCalculator.Tests.Application.Services;

[TestClass]
public class ProductionLineModelServiceTest
{
    [TestMethod]
    public void ProductionLineModelService_GetProductionLinesForItem()
    {
        //arrange
        ProductionLineModelService prodLineService = new ProductionLineModelService(new RecipeModelService());


        //act
        List<ProductionLineModel> productionLines = prodLineService.GetProductionLinesForItem(Items.IronRod);

        //assert
        Assert.AreEqual(productionLines.Count, 5);
    }

    [TestMethod]
    public void ProductionLineModelService_GetProductionLineBalanceItemOnly()
    {
        //arrange
        RecipeModelService recipeModelService = new();

        ICollection<RecipeModel> usedRecipes = new HashSet<RecipeModel>();

        usedRecipes.Add(Recipes.Screw); 
        usedRecipes.Add(Recipes.IronRod);
        usedRecipes.Add(Recipes.IronIngot);
        usedRecipes.Add(Recipes.HeavyOilResidue);

        recipeModelService.UsedRecipes = usedRecipes;

        ProductionLineModelService prodLineService = new ProductionLineModelService(recipeModelService);

        ProductionLineModel productionLine = new ProductionLineModel();

        List<ProcessStepModel> processSteps = new List<ProcessStepModel>()
        {
            new ProcessStepModel() { Recipe = Recipes.Screw},
            new ProcessStepModel() { Recipe = Recipes.IronRod},
            new ProcessStepModel() { Recipe = Recipes.IronIngot},
            new ProcessStepModel() { Recipe = Recipes.HeavyOilResidue}
        };

        productionLine.ProcessSteps = processSteps;

        //act
        ICollection<ItemBalanceModel> result = prodLineService.GetProductionLineBalanceItemOnly(productionLine);

        //assert
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronRod.Name && x.InAmount == 1 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.Screw.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronOre.Name && x.InAmount == 1 && x.OutAmount == 0));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronIngot.Name && x.InAmount == 1 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.Oil.Name && x.InAmount == 1 && x.OutAmount == 0));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.HeavyOilResidue.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.PolymerResin.Name && x.InAmount == 0 && x.OutAmount == 1));
    }

    [TestMethod]
    public void ProductionLineModelService_CalcOneStep()
    {
        //arrange
        RecipeModelService recipeModelService = new();

        ICollection<RecipeModel> usedRecipes = new HashSet<RecipeModel>();

        usedRecipes.Add(Recipes.Screw);
        usedRecipes.Add(Recipes.IronRod);
        usedRecipes.Add(Recipes.IronIngot);
        usedRecipes.Add(Recipes.IronAlloyIngot);
        usedRecipes.Add(Recipes.PureIronIngot);
        usedRecipes.Add(Recipes.SteelRod);

        recipeModelService.UsedRecipes = usedRecipes;

        ProductionLineModelService prodLineService = new ProductionLineModelService(recipeModelService);

        ProductionLineModel productionLine = new ProductionLineModel();

        List<ProcessStepModel> processSteps = new List<ProcessStepModel>()
        {
            new ProcessStepModel() { Recipe = Recipes.Screw}
        };

        productionLine.ProcessSteps = processSteps;

        //act
        ICollection<ProductionLineModel> result1 = prodLineService.CalcOneStep(productionLine);


        // was ausdenken für assert
        ProductionLineModel prductionLine2 = result1.First();
        ICollection<ProductionLineModel> result2 = prodLineService.CalcOneStep(prductionLine2);

        //assert
        Assert.IsTrue(result1.Count() == 2);
        Assert.IsTrue(result2.Count() == 3);

    }
}
