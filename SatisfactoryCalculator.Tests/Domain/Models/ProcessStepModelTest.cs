using SatisfactoryCalculator.Domain.Models;
using SatisfactoryCalculator.Infrastructure.Persistence.StaticDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryCalculator.Tests.Domain.Models;

[TestClass]
public class ProcessStepModelTest
{
    [TestMethod]
    public void ProcessStepModel_GetBalanceItemOnly()
    {
        //arrange

        ProcessStepModel processStep1 = new ProcessStepModel() { Recipe = Recipes.Screw };
        ProcessStepModel processStep2 = new ProcessStepModel() { Recipe = Recipes.IronRod };
        ProcessStepModel processStep3 = new ProcessStepModel() { Recipe = Recipes.IronIngot };
        ProcessStepModel processStep4 = new ProcessStepModel() { Recipe = Recipes.HeavyOilResidue };


        //act
        ICollection<ItemBalanceModel> result1 = processStep1.GetBalanceItemOnly();
        ICollection<ItemBalanceModel> result2 = processStep2.GetBalanceItemOnly();
        ICollection<ItemBalanceModel> result3 = processStep3.GetBalanceItemOnly();
        ICollection<ItemBalanceModel> result4 = processStep4.GetBalanceItemOnly();

        //assert
        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.IronRod.Name && x.InAmount == 1 && x.OutAmount == 0));
        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.Screw.Name && x.InAmount == 0 && x.OutAmount == 1));

        Assert.IsTrue(result2.Any(x => x.Item.Name == Items.IronRod.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result2.Any(x => x.Item.Name == Items.IronIngot.Name && x.InAmount == 1 && x.OutAmount == 0));

        Assert.IsTrue(result3.Any(x => x.Item.Name == Items.IronIngot.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result3.Any(x => x.Item.Name == Items.IronOre.Name && x.InAmount == 1 && x.OutAmount == 0));

        Assert.IsTrue(result4.Any(x => x.Item.Name == Items.Oil.Name && x.InAmount == 1 && x.OutAmount == 0));
        Assert.IsTrue(result4.Any(x => x.Item.Name == Items.HeavyOilResidue.Name && x.InAmount == 0 && x.OutAmount == 1));
        Assert.IsTrue(result4.Any(x => x.Item.Name == Items.PolymerResin.Name && x.InAmount == 0 && x.OutAmount == 1));
    }
}
