using SatisfactoryCalculator.Application.Services;
using SatisfactoryCalculator.Domain.Models;
using SatisfactoryCalculator.Infrastructure.Persistence.StaticDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryCalculator.Tests.Domain.Models;

[TestClass]
public class ProductionLineModelTest
{
    [TestMethod]
    public void ProductionLineModelService_GetProductionLineBalance()
    {
        //arrange
        ProductionLineModel productionLine = new ProductionLineModel();

        ProcessStepModel process1 = new ProcessStepModel() { Recipe = Recipes.Screw };
        process1.SetProcessStepTarget(new ItemWithAmount() { Amount = 300, Item = Items.Screw });

        ProcessStepModel process2 = new ProcessStepModel() { Recipe = Recipes.IronRod };
        process2.SetProcessStepTarget(new ItemWithAmount() { Amount = 100, Item = Items.IronRod });

        ProcessStepModel process3 = new ProcessStepModel() { Recipe = Recipes.IronIngot };
        process3.SetProcessStepTarget(new ItemWithAmount() { Amount = 110, Item = Items.IronIngot });

        ProcessStepModel process4 = new ProcessStepModel() { Recipe = Recipes.HeavyOilResidue };
        process4.SetProcessStepTarget(new ItemWithAmount() { Amount = 25.67m, Item = Items.HeavyOilResidue });

        List<ProcessStepModel> processSteps = new List<ProcessStepModel>()
        {
           process1,
           process2,
           process3,
           process4,
        };

        productionLine.ProcessSteps = processSteps;

        //act
        ICollection<ItemBalanceModel> result = productionLine.GetBalance();

        //assert
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronOre.Name && x.NeededAmount == 110 && x.ProducedAmount == 0));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronIngot.Name && x.NeededAmount == 100m && x.ProducedAmount == 110));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronRod.Name && x.NeededAmount == 75m && x.ProducedAmount == 100));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.Screw.Name && x.NeededAmount == 0 && x.ProducedAmount == 300));

        Assert.IsTrue(result.Any(x => x.Item.Name == Items.Oil.Name && x.NeededAmount == 19.26m && x.ProducedAmount == 0));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.HeavyOilResidue.Name && x.NeededAmount == 0 && x.ProducedAmount == 25.67m));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.PolymerResin.Name && x.NeededAmount == 0 && x.ProducedAmount == 12.83m));
    }
}
