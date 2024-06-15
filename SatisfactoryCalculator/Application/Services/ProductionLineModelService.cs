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

        //// suche die Rezepte für das gegebene Model
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

        ICollection<ItemBalanceModel> Itembalance = productionLineModel.GetBalance();

        ItemBalanceModel? itemBalance = Itembalance.First(x => x.NeededAmount > x.ProducedAmount) ?? throw new Exception();

        ICollection<RecipeModel> recipes = recipeModelService.GetMainRecipes(itemBalance.Item);

        if (recipes.Count == 0)
        {
            productionLineModel.CalculationIsDone = true;
            result.Add(productionLineModel);
            return result;
        }

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

}
