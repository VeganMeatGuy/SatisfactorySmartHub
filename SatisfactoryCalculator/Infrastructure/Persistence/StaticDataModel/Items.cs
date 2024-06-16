using SatisfactoryCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryCalculator.Infrastructure.Persistence.StaticDataModel;

internal static class Items
{
    public static ItemModel IronOre => new() { Name = "Iron Ore" };
    public static ItemModel CopperOre => new() { Name = "Copper Ore" };
    public static ItemModel Limestone => new() { Name = "Limestone" };
    public static ItemModel Concrete => new() { Name = "Concrete" };
    public static ItemModel Coal => new() { Name = "Coal" };
    public static ItemModel CateriumOre => new() { Name = "CateriumOre" };
    public static ItemModel RawQuartz => new() { Name = "RawQuartz" };
    public static ItemModel Sulfur => new() { Name = "Sulfur" };
    public static ItemModel Bauxite => new() { Name = "Bauxite" };
    public static ItemModel Uranium => new() { Name = "Uranium" };
    public static ItemModel Water => new() { Name = "Water" };
    public static ItemModel Oil => new() { Name = "Oil" };
    public static ItemModel IronIngot => new() { Name = "Iron Ingot" };
    public static ItemModel IronRod => new() { Name = "Iron Rod" };
    public static ItemModel Screw => new() { Name = "Screw" };
    public static ItemModel ModularFrame => new() { Name = "Modular Frame" };
    public static ItemModel SteelIngot => new() { Name = "Steel Ingot" };
    public static ItemModel SteelBeam => new() { Name = "Steel Beam" };
    public static ItemModel SteelPipe => new () { Name = "Steel Pipe" };
    public static ItemModel EncasedIndustrialBeam => new() { Name = "Encased Industrial Beam" };
    public static ItemModel HeavyModularFrame => new() { Name = "Heavy Modular Frame" };
    public static ItemModel HeavyOilResidue => new() { Name = "Heavy Oil Residue" };
    public static ItemModel Fuel => new() { Name = "Fuel" };
    public static ItemModel PolymerResin => new() { Name = "Polymer Resin" };
    public static ItemModel PetroleumCoke => new () { Name = "Petroleum Coke" };
    public static ItemModel AluminiaSolution => new() { Name = "Aluminia Solution" };
    public static ItemModel AluminiumScrap => new() { Name = "Aluminium Scrap" };

}
