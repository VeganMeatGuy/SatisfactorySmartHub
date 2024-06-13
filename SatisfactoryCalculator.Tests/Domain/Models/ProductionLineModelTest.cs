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
    public void ProductionLineModelService_GetProductionLineBalanceItemOnly()
    {
        //arrange
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
        ICollection<ItemBalanceModel> result = productionLine.GetBalanceItemOnly();

        //assert
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronRod.Name && x.InAmount == 1 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.Screw.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronOre.Name && x.InAmount == 1 && x.OutAmount == 0));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.IronIngot.Name && x.InAmount == 1 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.Oil.Name && x.InAmount == 1 && x.OutAmount == 0));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.HeavyOilResidue.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result.Any(x => x.Item.Name == Items.PolymerResin.Name && x.InAmount == 0 && x.OutAmount == 1));
    }
}
