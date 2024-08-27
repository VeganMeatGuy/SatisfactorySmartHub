﻿using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories.StaticRepositories.StaticData;

internal static class Recipes
{
    #region IronIngot
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
    #endregion

    #region IronRod
    internal static RecipeModel IronRod = new()
    {
        Name = "Iron Rod",
        Machine = Machines.Constructor,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.IronIngot, Amount = 15m }
        },
        MainProduct = new() { Item = Items.IronRod, Amount = 15m }
    };

    internal static RecipeModel SteelRod = new()
    {
        Name = "Steel Rod",
        Machine = Machines.Constructor,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.SteelIngot, Amount = 12m },
        },
        MainProduct = new() { Item = Items.IronRod, Amount = 48m }
    };
    #endregion

    #region Screw
    internal static RecipeModel Screw = new()
    {
        Name = "Screw",
        Machine = Machines.Constructor,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.IronRod, Amount = 10m },
        },
        MainProduct = new() { Item = Items.Screw, Amount = 40m }
    };

    internal static RecipeModel CastScrew = new()
    {
        Name = "Cast Screw",
        Machine = Machines.Constructor,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.IronIngot, Amount = 12.5m },
        },
        MainProduct = new() { Item = Items.Screw, Amount = 50m }
    };

    internal static RecipeModel SteelScrew = new()
    {
        Name = "Steel Screw",
        Machine = Machines.Constructor,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.SteelBeam, Amount = 5m },
        },
        MainProduct = new() { Item = Items.Screw, Amount = 260m }
    };
    #endregion

    #region SteelIngot
    internal static RecipeModel SteelIngot = new()
    {
        Name = "Steel Ingot",
        Machine = Machines.Foundry,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.IronOre, Amount = 45m },
            new() { Item = Items.Coal, Amount = 45m }
        },
        MainProduct = new() { Item = Items.SteelIngot, Amount = 45m }
    };

    internal static RecipeModel CokeSteelIngot = new()
    {
        Name = "Coke Steel Ingot",
        Machine = Machines.Foundry,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.IronOre, Amount = 75m },
            new() { Item = Items.PetroleumCoke, Amount = 75m }
        },
        MainProduct = new() { Item = Items.SteelIngot, Amount = 100m }
    };
    #endregion

    #region SteelBeam
    internal static RecipeModel SteelBeam = new()
    {
        Name = "Steel Beam",
        Machine = Machines.Constructor,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.SteelIngot, Amount = 60m },
        },
        MainProduct = new() { Item = Items.SteelBeam, Amount = 45m }
    };
    #endregion

    #region Heavy Modular Frame
    internal static RecipeModel HeavyEncasedFrame = new()
    {
        Name = "Heavy Encased Frame",
        Machine = Machines.Manufacturer,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.ModularFrame, Amount = 7.5m },
            new() { Item = Items.EncasedIndustrialBeam, Amount = 9.375m },
            new() { Item = Items.SteelPipe, Amount = 33.75m },
            new() { Item = Items.Concrete, Amount = 20.625m },
        },
        MainProduct = new() { Item = Items.HeavyModularFrame, Amount = 2.8125m },
    };
    #endregion

    #region HeavyOil
    internal static RecipeModel HeavyOilResidue = new()
    {
        Name = "Heavy Oil Residue",
        Machine = Machines.Refinery,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.Oil, Amount = 30m },
        },
        MainProduct = new() { Item = Items.HeavyOilResidue, Amount = 40m },
        Byproducts = new List<ItemWithAmount>()
        {
            new() { Item = Items.PolymerResin, Amount = 20m },
        }
    };
    #endregion

    #region Fuel
    internal static RecipeModel Fuel = new()
    {
        Name = "Fuel",
        Machine = Machines.Refinery,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.Oil, Amount = 60m },
        },
        MainProduct = new() { Item = Items.Fuel, Amount = 40m },
        Byproducts = new List<ItemWithAmount>()
        {
            new() { Item = Items.PolymerResin, Amount = 30m },
        }
    };
    #endregion

    #region AluminumScrap
    internal static RecipeModel AluminumScrap = new()
    {
        Name = "Aluminum Scrap",
        Machine = Machines.Refinery,
        Ingredients = new List<ItemWithAmount>()
        {
            new() { Item = Items.AluminiaSolution, Amount = 240m },
            new() { Item = Items.Coal, Amount = 120m },
        },
        MainProduct = new() { Item = Items.AluminiumScrap, Amount = 360m },
        Byproducts = new List<ItemWithAmount>()
        {
            new() { Item = Items.Water, Amount = 120m },
        }
    };
    #endregion
}
