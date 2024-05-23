﻿using System.Reflection.PortableExecutable;

namespace SatisfactoryCalculator.Domain.Models;

internal class RecipeModel
{
    private string _name = string.Empty;
    private MachineModel _machine = new();
    private ICollection<ItemWithAmount> _ingredients = new HashSet<ItemWithAmount>();
    private ItemWithAmount _mainProduct = new();
    private ICollection<ItemWithAmount> _byproducts = new HashSet<ItemWithAmount>();

    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public MachineModel Machine
    {
        get => _machine;
        set => _machine = value;
    }
    public ICollection<ItemWithAmount> Ingredients
    {
        get => _ingredients;
        set => _ingredients = value;
    }
    public ItemWithAmount MainProduct
    {
        get => _mainProduct;
        set => _mainProduct = value;
    }
    public ICollection<ItemWithAmount> Byproducts
    {
        get => _byproducts;
        set => _byproducts = value;
    }
}
