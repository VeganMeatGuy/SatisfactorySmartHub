﻿using SatisfactoryCalculator.Domain.Models;
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
    public void ProcessStepModel_SetProducedAmount_ExampleHeavyEncasedFrame()
    {
        ProcessStepModel processStep1 = new ProcessStepModel() { Recipe = Recipes.HeavyEncasedFrame };

        processStep1.SetProductionTarget(new ItemWithAmount() { Amount = 2.15m, Item = Items.HeavyModularFrame });

        ICollection<ItemBalanceModel> result1 = processStep1.GetBalance();

        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.ModularFrame.Name && x.NeededAmount == 5.74m && x.ProducedAmount == 0));
        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.EncasedIndustrialBeam.Name && x.NeededAmount == 7.17m && x.ProducedAmount == 0));
        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.SteelPipe.Name && x.NeededAmount == 25.8m && x.ProducedAmount == 0));
        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.Concrete.Name && x.NeededAmount == 15.77m && x.ProducedAmount == 0));
        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.HeavyModularFrame.Name && x.NeededAmount == 0 && x.ProducedAmount == 2.15m));
    }

    [TestMethod]
    public void ProcessStepModel_SetProducedAmount_ExampleAluminumScrap()
    {
        ProcessStepModel processStep1 = new ProcessStepModel() { Recipe = Recipes.AluminumScrap };

        processStep1.SetProductionTarget(new ItemWithAmount() { Amount = 272.26m, Item = Items.AluminiumScrap });

        ICollection<ItemBalanceModel> result1 = processStep1.GetBalance();

        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.AluminiaSolution.Name && x.NeededAmount == 181.51m && x.ProducedAmount == 0));
        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.Coal.Name && x.NeededAmount == 90.76m && x.ProducedAmount == 0));
        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.AluminiumScrap.Name && x.NeededAmount == 0 && x.ProducedAmount == 272.26m));
        Assert.IsTrue(result1.Any(x => x.Item.Name == Items.Water.Name && x.NeededAmount == 0 && x.ProducedAmount == 90.75m));
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void ProcessStepModel_SetProducedAmount_ThrowsExceptionWhenMoreThen3Decimals()
    {
        ProcessStepModel processStep1 = new ProcessStepModel() { Recipe = Recipes.AluminumScrap };

        processStep1.SetProductionTarget(new ItemWithAmount() { Amount = 272.265m, Item = Items.AluminiumScrap });
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void ProcessStepModel_SetProducedAmount_ThrowsExceptionWhenProcessIstNotProducingWantedItem()
    {
        ProcessStepModel processStep1 = new ProcessStepModel() { Recipe = Recipes.AluminumScrap };

        processStep1.SetProductionTarget(new ItemWithAmount() { Amount = 272.265m, Item = Items.Screw });
    }
}
