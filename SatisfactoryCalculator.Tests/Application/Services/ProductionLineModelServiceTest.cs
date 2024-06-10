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
        ProductionLineModelService prodLineService = new ProductionLineModelService(new RecipeModelService());

        ProductionLineModel productionLine = new ProductionLineModel();

        List<ProcessStepModel> processSteps = new List<ProcessStepModel>()
        {
            new ProcessStepModel() { Recipe = Recipes.Screw},
            new ProcessStepModel() { Recipe = Recipes.IronIngot},
            new ProcessStepModel() { Recipe = Recipes.HeavyOilResidue}
        };

        productionLine.ProcessSteps = processSteps;

        //act
        ICollection<ItemBalanceModel> result = prodLineService.GetProductionLineBalanceItemOnly(productionLine);

        //assert
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronRod.Name && x.InAmount == 1 && x.OutAmount == 0));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.Screw.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronOre.Name && x.InAmount == 1 && x.OutAmount == 0));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronIngot.Name && x.InAmount == 0 && x.OutAmount == 1));

        Assert.IsTrue(result.Any(x => x.Item.Name == Items.Oil.Name && x.InAmount == 1 && x.OutAmount == 0));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.HeavyOilResidue.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.PolymerResin.Name && x.InAmount == 0 && x.OutAmount == 1));
    }

    [TestMethod]
    public void ProductionLineModelService_GetProductionLineBalanceItemOnlyBugFix()
    {
        //arrange
        ProductionLineModelService prodLineService = new ProductionLineModelService(new RecipeModelService());

        ProductionLineModel productionLine = new ProductionLineModel();

        List<ProcessStepModel> processSteps = new List<ProcessStepModel>()
        {
            new ProcessStepModel() { Recipe = Recipes.Screw},
            new ProcessStepModel() { Recipe = Recipes.IronRod},
        };

        productionLine.ProcessSteps = processSteps;

        //act
        ICollection<ItemBalanceModel> result = prodLineService.GetProductionLineBalanceItemOnly(productionLine);

        //assert
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronRod.Name && x.InAmount == 1 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.Screw.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronIngot.Name && x.InAmount == 1 && x.OutAmount == 0));
    }

    [TestMethod]
    public void ProductionLineModelService_CalcOneStep()
    {
        //arrange
        ProductionLineModelService prodLineService = new ProductionLineModelService(new RecipeModelService());

        ProductionLineModel productionLine = new ProductionLineModel();

        List<ProcessStepModel> processSteps = new List<ProcessStepModel>()
        {
            new ProcessStepModel() { Recipe = Recipes.Screw}
        };

        productionLine.ProcessSteps = processSteps;

        //act
        ICollection<ProductionLineModel> result1 = prodLineService.CalcOneStep(productionLine);
        ICollection<ProductionLineModel> result2 = prodLineService.CalcOneStep(result1.First());

        //assert
        Assert.IsTrue(false);

    }
}
