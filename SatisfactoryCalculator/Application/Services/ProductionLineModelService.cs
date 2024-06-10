using SatisfactoryCalculator.Domain.Models;
using SatisfactoryCalculator.Infrastructure.Persistence.StaticDataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryCalculator.Application.Services;

internal class ProductionLineModelService(RecipeModelService recipeModelService)
{
    public List<ProductionLineModel> GetProductionLinesForItem(ItemModel model)
    {
        ICollection<ProductionLineModel> openProductionLines = new HashSet<ProductionLineModel>();
        ICollection<ProductionLineModel> finishedProductionLines = new HashSet<ProductionLineModel>();

        // suche die Rezepte für das gegebene Model
        ICollection<RecipeModel> recipes = recipeModelService.GetMainRecipes(model);

        //je Rezept wird ein ProductionLineModel & das finale ProcessStepModel angelegt
        foreach (RecipeModel recipe in recipes)
        {
            ProcessStepModel processStepModel = new();
            processStepModel.Recipe = recipe;
            ProductionLineModel productionLine = new();
            productionLine.ProcessSteps.Add(processStepModel);
            openProductionLines.Add(productionLine);
        }

        while (openProductionLines.Count > 0)
        {

            ICollection<ProductionLineModel> newOpenProductionLines = new HashSet<ProductionLineModel>();

            foreach (var productionLine in openProductionLines)
            {
                ICollection<ProductionLineModel> calculatedProductionLines = CalcOneStep(productionLine);

                foreach (var calculatedProductionLine in calculatedProductionLines)
                    if (calculatedProductionLine.CalculationIsDone)
                        finishedProductionLines.Add(calculatedProductionLine);
                    else
                        newOpenProductionLines.Add(calculatedProductionLine);
            }

            openProductionLines = newOpenProductionLines;

        }

        return finishedProductionLines.ToList();
    }


    public ICollection<ProductionLineModel> CalcOneStep(ProductionLineModel productionLineModel)
    {
        ICollection<ProductionLineModel> result = new HashSet<ProductionLineModel>();


        ICollection<ItemBalanceModel> Itembalance = GetProductionLineBalanceItemOnly(productionLineModel);

        ItemBalanceModel? itemBalance = Itembalance.First(x => x.InAmount > x.OutAmount) ?? throw new Exception();

        ICollection<RecipeModel> recipes = recipeModelService.GetMainRecipes(itemBalance.Item);


        foreach (RecipeModel recipe in recipes)
        {
            ProductionLineModel newProductionLine = new();
            newProductionLine.ProcessSteps = productionLineModel.ProcessSteps.ToList();

            ProcessStepModel processStepModel = new();
            processStepModel.Recipe = recipe;

            newProductionLine.ProcessSteps.Add(processStepModel);
            result.Add(newProductionLine);
        }

        return result;
    }

    public ICollection<ItemBalanceModel> GetProductionLineBalanceItemOnly(ProductionLineModel productionLine)
    {
        ICollection<ItemBalanceModel> result = new HashSet<ItemBalanceModel>();

        foreach (ProcessStepModel processStep in productionLine.ProcessSteps)
        {

            ItemWithAmount pro = processStep.Recipe.MainProduct;
            ICollection<ItemWithAmount> byp = processStep.Recipe.Byproducts;
            ICollection<ItemWithAmount> ing = processStep.Recipe.Ingredients;

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
        }
        return result;
    }



}
