using SatisfactoryCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        //je Rezept wird ein ProductionLineModel & ein ProcessStepModel angelegt
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
            ProductionLineModel activeProdLine = openProductionLines.First();

            var possipleLastSteps = activeProdLine.ProcessSteps.Where(x => x.PostStep == null);

            if (possipleLastSteps.Count() > 1)
                throw new Exception();

            ProcessStepModel lastStep = possipleLastSteps.First();

            //finde die Zutaten für den letzten Schritt ein ProcessStep

            foreach (ItemWithAmount Zutat in lastStep.Recipe.Ingredients)
            {

            }
        }



        //jetzt habe ich eine production Line mit einem Prozessschritt
        //nun muss ich der produktionslinie noch die restlichen Prozessschritte hinzufügen


        // für jedes ProcessStepModel wird in den Zutaten geschaut, und je zutat nach dem rezept gesucht



        return null;
        //return productionLines.ToList();
    }

}
