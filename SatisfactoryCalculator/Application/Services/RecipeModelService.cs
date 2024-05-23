using SatisfactoryCalculator.Domain.Models;
using SatisfactoryCalculator.Infrastructure.Persistence.StaticDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryCalculator.Application.Services;

internal class RecipeModelService
{
    public decimal GetNormalizedPowerConsumtion(RecipeModel recipe)
    {
        decimal productAmount = recipe.MainProduct.Amount;
        decimal machinePowerConsumption = recipe.Machine.PowerConsumption;

        decimal result = 100 / productAmount * machinePowerConsumption;

        return  Math.Round(result,4);
    }
     
    public ICollection<RecipeModel> GetMainRecipes(ItemModel model)
    {
        ICollection<RecipeModel> recipes = Recipes.RecipeList;
        return recipes.Where(x => x.MainProduct.Item.Name == model.Name).ToList();
    }
}
