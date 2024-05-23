using SatisfactoryCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryCalculator.Infrastructure.Persistence.StaticDataModel;

internal static class Recipes
{
    internal static ICollection<RecipeModel> RecipeList => new List<RecipeModel>()
    {
        IronIngot,
        IronAlloyIngot,
        PureIronIngot

    };

    internal static RecipeModel IronIngot = new()
    {
        Name = "Iron Ingot",
        Machine = Machines.Smelter,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.IronOre, Amount = 30m }
        },
        MainProduct = new() { Item = Items.IronIngot, Amount = 30m }
    };

    internal static RecipeModel IronAlloyIngot = new()
    {
        Name = "Iron Alloy Ingot",
        Machine = Machines.Foundry,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.IronOre, Amount = 20m },
            new() { Item = Items.CopperOre, Amount = 20m }
        },
        MainProduct = new() { Item = Items.IronIngot, Amount = 50m }
    };

    internal static RecipeModel PureIronIngot = new()
    {
        Name = "Pure Iron Ingot",
        Machine = Machines.Refinery,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.IronOre, Amount = 35m },
            new() { Item = Items.Water, Amount = 20m }
        },
        MainProduct = new() { Item = Items.IronIngot, Amount = 65m }
    };

}
