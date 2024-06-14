using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SatisfactoryCalculator.Domain.Models;

internal class ProcessStepModel
{
    private RecipeModel _recipe = new();

    public RecipeModel Recipe
    {
        get => _recipe;
        set => _recipe = value;
    }

    public ICollection<ItemBalanceModel> GetBalanceItemOnly()
    {
        ICollection<ItemBalanceModel> result = new HashSet<ItemBalanceModel>();

        ItemWithAmount pro = Recipe.MainProduct;
        ICollection<ItemWithAmount> byp = Recipe.Byproducts;
        ICollection<ItemWithAmount> ing = Recipe.Ingredients;

        if (result.Any(x => x.Item.Name == pro.Item.Name))
            result.First(x => x.Item.Name == pro.Item.Name).OutAmount += 1;
        else
            result.Add(new() { Item = pro.Item, OutAmount = 1 });

        foreach (ItemWithAmount bypitem in byp)
        {
            if (result.Any(x => x.Item.Name == bypitem.Item.Name))
                result.First(x => x.Item.Name == bypitem.Item.Name).OutAmount += 1;
            else
                result.Add(new() { Item = bypitem.Item, OutAmount = 1 });
        }

        foreach (ItemWithAmount ingitem in ing)
        {
            if (result.Any(x => x.Item.Name == ingitem.Item.Name))
                result.First(x => x.Item.Name == ingitem.Item.Name).InAmount += 1;
            else
                result.Add(new() { Item = ingitem.Item, InAmount = 1 });
        }
        return result; 
    
    }
}
