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
    public void ProductionLineModelService_CalcOneStep_BasicFunction()
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

        var QueryWantedProductionLine =
            from prod in result1
            from step in prod.ProcessSteps
            where step.Recipe == Recipes.IronRod
            select prod;

        ICollection<ProductionLineModel> resultQueryWantedProductionLine = QueryWantedProductionLine.ToList();
        if (resultQueryWantedProductionLine.Count() != 1)
            throw new AssertFailedException("Es darf nur eine derartige Liste geben!");

        ICollection<ProductionLineModel> result2 = prodLineService.CalcOneStep(resultQueryWantedProductionLine.First());


        //assert

        Assert.IsTrue(result1.Count() == 2);
        List<bool[]> testDataSet1 = new List<bool[]>();
        foreach (ProductionLineModel prod in result1)
        {

            bool[] dataSet = new bool[3];
            if (prod.ProcessSteps.Any(x => x.Recipe.Name == Recipes.Screw.Name))
                dataSet[0] = true;

            if (prod.ProcessSteps.Any(x => x.Recipe.Name == Recipes.IronRod.Name))
                dataSet[1] = true;

            if (prod.ProcessSteps.Any(x => x.Recipe.Name == Recipes.SteelRod.Name))
                dataSet[2] = true;
            testDataSet1.Add(dataSet);
        }

        Assert.IsTrue(testDataSet1.Count(x => x[0] == true && x[1] == true && x[2] == false) == 1);
        Assert.IsTrue(testDataSet1.Count(x => x[0] == true && x[1] == true && x[2] == false) == 1);

        Assert.IsTrue(testDataSet1.Count(x => x[0] == true) == 2);
        Assert.IsTrue(testDataSet1.Count(x => x[1] == true) == 1);
        Assert.IsTrue(testDataSet1.Count(x => x[2] == true) == 1);

        Assert.IsTrue(result2.Count() == 3);
        List<bool[]> testDataSet2 = new List<bool[]>();
        foreach (ProductionLineModel prod in result2)
        {
            bool[] DataSet = new bool[5];
            if (prod.ProcessSteps.Any(x => x.Recipe.Name == Recipes.Screw.Name))
                DataSet[0] = true;

            if (prod.ProcessSteps.Any(x => x.Recipe.Name == Recipes.IronRod.Name))
                DataSet[1] = true;

            if (prod.ProcessSteps.Any(x => x.Recipe.Name == Recipes.IronIngot.Name))
                DataSet[2] = true;

            if (prod.ProcessSteps.Any(x => x.Recipe.Name == Recipes.IronAlloyIngot.Name))
                DataSet[3] = true;

            if (prod.ProcessSteps.Any(x => x.Recipe.Name == Recipes.PureIronIngot.Name))
                DataSet[4] = true;
            testDataSet2.Add(DataSet);
        }
        Assert.IsTrue(testDataSet2.Count(x => x[0] == true && x[1] == true && x[2] == true && x[3] == false && x[4] == false) == 1);
        Assert.IsTrue(testDataSet2.Count(x => x[0] == true && x[1] == true && x[2] == false && x[3] == true && x[4] == false) == 1);
        Assert.IsTrue(testDataSet2.Count(x => x[0] == true && x[1] == true && x[2] == false && x[3] == false && x[4] == true) == 1);

        Assert.IsTrue(testDataSet2.Count(x => x[0] == true) == 3);
        Assert.IsTrue(testDataSet2.Count(x => x[1] == true) == 3);
        Assert.IsTrue(testDataSet2.Count(x => x[2] == true) == 1);
        Assert.IsTrue(testDataSet2.Count(x => x[3] == true) == 1);
        Assert.IsTrue(testDataSet2.Count(x => x[4] == true) == 1);
    }

    public void ProductionLineModelService_CalcOneStep_SetCalculationIsDone()
    {
        //arrange
        RecipeModelService recipeModelService = new();

        ProductionLineModelService prodLineService = new ProductionLineModelService(recipeModelService);
        ProductionLineModel productionLine = new ProductionLineModel();

        List<ProcessStepModel> processSteps = new List<ProcessStepModel>()
        {
            new ProcessStepModel() { Recipe = Recipes.IronIngot}
        };

        productionLine.ProcessSteps = processSteps;

        //act
        ICollection<ProductionLineModel> result1 = prodLineService.CalcOneStep(productionLine);


        //assert
        Assert.IsTrue(result1.Count == 1);
        Assert.IsTrue(result1.First().CalculationIsDone = true);
    }
}
