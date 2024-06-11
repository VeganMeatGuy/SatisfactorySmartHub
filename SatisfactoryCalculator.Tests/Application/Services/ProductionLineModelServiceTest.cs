using Newtonsoft.Json;
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

        ProductionLineModel ExpectedResult1 = new ProductionLineModel();
        ExpectedResult1.ProcessSteps.Add(new() { Recipe = Recipes.Screw });
        ExpectedResult1.ProcessSteps.Add(new() { Recipe = Recipes.IronRod });

        //act
        ICollection<ProductionLineModel> result1 = prodLineService.CalcOneStep(productionLine);

        var QueryWantedProductionLine =
            from prod in result1
            from step in prod.ProcessSteps
            where step.Recipe == Recipes.IronRod
            select prod;

        ICollection<ProductionLineModel> resultQueryWantedProductionLine = QueryWantedProductionLine.ToList();

        ICollection<ProductionLineModel> result2 = prodLineService.CalcOneStep(resultQueryWantedProductionLine.First());

        var object1json = JsonConvert.SerializeObject(resultQueryWantedProductionLine.First());
        var object2json = JsonConvert.SerializeObject(ExpectedResult1);

        //assert

        Assert.AreEqual(object1json, object2json);

        Assert.IsTrue(resultQueryWantedProductionLine.Count() == 1);

        Assert.IsTrue(result1.Count() == 2);



        Assert.IsTrue(result2.Count() == 3);

    }
}
