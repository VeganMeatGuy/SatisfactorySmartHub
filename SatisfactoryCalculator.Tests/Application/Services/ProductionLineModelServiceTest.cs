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
        RecipeModelService recipeModelService = new();
        ICollection<RecipeModel> usedRecipes = new HashSet<RecipeModel>();

        usedRecipes.Add(Recipes.Screw);
        usedRecipes.Add(Recipes.SteelScrew);

        usedRecipes.Add(Recipes.SteelBeam);

        usedRecipes.Add(Recipes.IronRod);
        usedRecipes.Add(Recipes.IronIngot);
        usedRecipes.Add(Recipes.PureIronIngot);
        usedRecipes.Add(Recipes.IronAlloyIngot);

        usedRecipes.Add(Recipes.SteelRod);
        usedRecipes.Add(Recipes.SteelIngot);
        usedRecipes.Add(Recipes.CokeSteelIngot);


        recipeModelService.UsedRecipes = usedRecipes;

        ProductionLineModelService prodLineService = new ProductionLineModelService(recipeModelService);

        //act
        List<ProductionLineModel> productionLines = 
            prodLineService.GetProductionLinesForItem(new ItemWithAmount() { Item = Items.Screw, Amount = 300 });

        //assert
        Assert.AreEqual( 7, productionLines.Count);
    }


    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void ProductionLineModelService_CalcOneStep_ThrowsExceptionWhenNoTarget()
    {
        //arrange
        RecipeModelService recipeModelService = new();
        ProductionLineModelService prodLineService = new ProductionLineModelService(recipeModelService);
        ProductionLineModel productionLine = new ProductionLineModel();
        ProcessStepModel process1 = new ProcessStepModel() { Recipe = Recipes.Screw };
        productionLine.ProcessSteps.Add(process1);

        var result = prodLineService.CalcOneStep(productionLine);
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

        ProcessStepModel process1 = new ProcessStepModel() { Recipe = Recipes.Screw };
        process1.SetProcessStepTarget(new ItemWithAmount() { Item = Items.Screw, Amount = 300 });


        List<ProcessStepModel> processSteps = new List<ProcessStepModel>()
        {
            process1,
        };

        productionLine.ProcessSteps = processSteps;

        //act
        ICollection<ProductionLineModel> result1 = prodLineService.CalcOneStep(productionLine);

        ICollection<ProductionLineModel> QueryResultWantedProductionLine =
            (from prod in result1
            from step in prod.ProcessSteps
            where step.Recipe == Recipes.IronRod
            select prod).ToList();

        if (QueryResultWantedProductionLine.Count() != 1)
            throw new AssertFailedException("Es darf nur eine derartige Liste geben!");

        ProductionLineModel Result1ExampleProductionLine = QueryResultWantedProductionLine.First();

        ICollection<ProductionLineModel> result2 = prodLineService.CalcOneStep(Result1ExampleProductionLine);


        //assert

        Assert.IsTrue(result1.Count() == 2);

        var balanceResult1ExampleProductionLine = Result1ExampleProductionLine.GetBalance();

        Assert.IsTrue(balanceResult1ExampleProductionLine.Any(x => x.Item.Name == Items.IronIngot.Name && x.NeededAmount == 75m && x.ProducedAmount == 0));
        Assert.IsTrue(balanceResult1ExampleProductionLine.Any(x => x.Item.Name == Items.IronRod.Name && x.NeededAmount == 75m && x.ProducedAmount == 75m));
        Assert.IsTrue(balanceResult1ExampleProductionLine.Any(x => x.Item.Name == Items.Screw.Name && x.NeededAmount == 0 && x.ProducedAmount == 300));

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
