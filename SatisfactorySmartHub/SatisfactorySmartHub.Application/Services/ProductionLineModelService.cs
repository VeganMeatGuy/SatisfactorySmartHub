namespace SatisfactorySmartHub.Application.Services;

internal class ProductionLineModelService(RecipeModelService recipeModelService)
{
    public List<ProductionLineModel> GetProductionLinesForItem(ItemWithAmount model)
    {
        ICollection<ProductionLineModel> openProductionLines = new HashSet<ProductionLineModel>();
        ICollection<ProductionLineModel> finishedProductionLines = new HashSet<ProductionLineModel>();

        //// suche die Rezepte für das gegebene Model
        ICollection<RecipeModel> recipes = recipeModelService.GetMainRecipes(model.Item);

        //je Rezept wird ein ProductionLineModel & das finale ProcessStepModel angelegt
        foreach (RecipeModel recipe in recipes)
        {
            ProcessStepModel processStepModel = new();
            processStepModel.Recipe = recipe;
            processStepModel.SetProcessStepTarget(model);
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
        //wenn es keinen ProcessStep mit einem Target gibt, kann ich auch nichts kalkulieren
        var calculableProzessSteps =
            from step in productionLineModel.ProcessSteps
            where step.ProcessStepTarget != null
            select step;

        if (calculableProzessSteps.ToList().Count < 1)
        {
            throw new Exception("Calc nur möglich, wenn mindestens ein Prozesschritt mit Ziel vorhanden ist.");
        }


        ICollection<ProductionLineModel> result = new HashSet<ProductionLineModel>();

        ICollection<ItemBalanceModel> Itembalance = productionLineModel.GetBalance();

        ItemBalanceModel? itemBalance = Itembalance.FirstOrDefault(x => x.NeededAmount > x.ProducedAmount);
        if (itemBalance == null)
        {
            productionLineModel.CalculationIsDone = true;
            result.Add(productionLineModel);
            return result;
        }

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
            processStepModel.SetProcessStepTarget(new ItemWithAmount() { Item = recipe.MainProduct.Item, Amount = itemBalance.NeededAmount });

            newProductionLine.ProcessSteps.Add(processStepModel);
            result.Add(newProductionLine);
        }

        return result;
    }

}
