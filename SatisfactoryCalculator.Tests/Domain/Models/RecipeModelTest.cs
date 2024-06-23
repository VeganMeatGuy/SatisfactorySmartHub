﻿using SatisfactorySmartHub.Domain.Enums;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistence.StaticDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Tests.Domain.Models;

[TestClass]
public class RecipeModelTest
{
    [TestMethod]
    public void RecipeModel_GetItemUsageInRecipe()
    {
        RecipeModel recipe = Recipes.AluminumScrap;

        Assert.AreEqual(RecipeComponentType.Ingredient, recipe.GetItemUsageInRecipe(Items.AluminiaSolution));
        Assert.AreEqual(RecipeComponentType.Ingredient, recipe.GetItemUsageInRecipe(Items.Coal));
        Assert.AreEqual(RecipeComponentType.MainProduct, recipe.GetItemUsageInRecipe(Items.AluminiumScrap));
        Assert.AreEqual(RecipeComponentType.ByProduct, recipe.GetItemUsageInRecipe(Items.Water));
        Assert.AreEqual(RecipeComponentType.NotIncluded, recipe.GetItemUsageInRecipe(Items.IronRod));

    }

}