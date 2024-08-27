using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.StaticRepositories.StaticData;
using System.Collections.ObjectModel;

namespace SatisfactorySmartHub.Domain.Tests.Models;

[TestClass]
public class ProductionSiteModelTest
{
    [TestMethod]
    public void ProductionSiteModelService_GetProductionSiteBalance()
    {
        //arrange
        ProductionSiteModel productionSite = new ProductionSiteModel();

        ProcessStepModel process1 = new ProcessStepModel() { Recipe = Recipes.Screw };
        process1.SetProcessStepTarget(new ItemWithAmount() { Amount = 300, Item = Items.Screw });

        ProcessStepModel process2 = new ProcessStepModel() { Recipe = Recipes.IronRod };
        process2.SetProcessStepTarget(new ItemWithAmount() { Amount = 100, Item = Items.IronRod });

        ProcessStepModel process3 = new ProcessStepModel() { Recipe = Recipes.IronIngot };
        process3.SetProcessStepTarget(new ItemWithAmount() { Amount = 110, Item = Items.IronIngot });

        ProcessStepModel process4 = new ProcessStepModel() { Recipe = Recipes.HeavyOilResidue };
        process4.SetProcessStepTarget(new ItemWithAmount() { Amount = 25.67m, Item = Items.HeavyOilResidue });

        ObservableCollection<ProcessStepModel> processSteps = new ObservableCollection<ProcessStepModel>()
        {
           process1,
           process2,
           process3,
           process4,
        };

        productionSite.ProcessSteps = processSteps;

        //act
        ICollection<ItemBalanceModel> result = productionSite.GetBalance();

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
