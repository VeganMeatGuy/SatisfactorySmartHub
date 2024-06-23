using SatisfactorySmartHub.Domain.Models.Enums;
using System.ComponentModel;

namespace SatisfactorySmartHub.Domain.Models;

internal class ProcessStepModel
{
    private RecipeModel _recipe = new();
    private ItemWithAmount? _processStepTarget;

    public RecipeModel Recipe
    {
        get => _recipe;
        set => _recipe = value;
    }

    public ItemWithAmount? ProcessStepTarget
    {
        get => _processStepTarget;
    }

    public void SetProcessStepTarget(ItemWithAmount targetItemWithAmount)
    {
        if (decimal.Round(targetItemWithAmount.Amount, 2) != targetItemWithAmount.Amount)
            throw new Exception("Input Menge darf maximal zwei Kommastellen haben.");

        switch (Recipe.GetItemUsageInRecipe(targetItemWithAmount.Item))
        {
            case RecipeComponentType.NotIncluded:
                throw new Exception("Item ist nicht im Rezept vorhanden.");
            default:
                _processStepTarget = targetItemWithAmount;
                break;
        }
    }

    public ICollection<ItemBalanceModel> GetBalance()
    {
        if (_processStepTarget == null)
            return CalculateBalanceWithoutTarget();

        switch (Recipe.GetItemUsageInRecipe(_processStepTarget.Item))
        {
            case RecipeComponentType.MainProduct:
                return CalculateBalanceProductTarget();
            case RecipeComponentType.Ingredient:
                return CalculateBalanceIngredientTarget();
            case RecipeComponentType.ByProduct:
                return CalculateBalanceByProductTarget();
            default:
                return CalculateBalanceWithoutTarget();
        }
    }

    private ICollection<ItemBalanceModel> CalculateBalanceProductTarget()
    {
        ICollection<ItemBalanceModel> balance = new HashSet<ItemBalanceModel>();

        decimal standardmenge = Recipe.MainProduct.Amount;
        decimal multiplikator = ProcessStepTarget.Amount / standardmenge;

        ItemBalanceModel MainProduct = new ItemBalanceModel();
        MainProduct.Item = Recipe.MainProduct.Item;
        MainProduct.ProducedAmount = ProcessStepTarget.Amount;

        balance.Add(MainProduct);


        foreach (ItemWithAmount bypitem in Recipe.Byproducts)
        {
            ItemBalanceModel byProduct = new ItemBalanceModel();
            byProduct.Item = bypitem.Item;
            byProduct.ProducedAmount = decimal.Round(multiplikator * bypitem.Amount, 2, MidpointRounding.ToNegativeInfinity);
            balance.Add(byProduct);
        }

        foreach (ItemWithAmount inItem in Recipe.Ingredients)
        {
            ItemBalanceModel ingredient = new ItemBalanceModel();
            ingredient.Item = inItem.Item;
            ingredient.NeededAmount = decimal.Round(multiplikator * inItem.Amount, 2, MidpointRounding.ToPositiveInfinity);
            balance.Add(ingredient);
        }

        return balance;
    }

    private ICollection<ItemBalanceModel> CalculateBalanceIngredientTarget()
    {

        ICollection<ItemBalanceModel> balance = new HashSet<ItemBalanceModel>();

        ItemWithAmount target = Recipe.Ingredients.First(x => x.Item.Name == ProcessStepTarget.Item.Name);

        decimal standardmenge = target.Amount;
        decimal multiplikator = ProcessStepTarget.Amount / standardmenge;

        ItemBalanceModel MainProduct = new ItemBalanceModel();
        MainProduct.Item = Recipe.MainProduct.Item;
        MainProduct.ProducedAmount = decimal.Round(multiplikator * Recipe.MainProduct.Amount, 2, MidpointRounding.ToNegativeInfinity);

        balance.Add(MainProduct);


        foreach (ItemWithAmount bypitem in Recipe.Byproducts)
        {
            ItemBalanceModel byProduct = new ItemBalanceModel();
            byProduct.Item = bypitem.Item;
            byProduct.ProducedAmount = decimal.Round(multiplikator * bypitem.Amount, 2, MidpointRounding.ToNegativeInfinity);
            balance.Add(byProduct);
        }

        foreach (ItemWithAmount inItem in Recipe.Ingredients)
        {
            ItemBalanceModel ingredient = new ItemBalanceModel();
            ingredient.Item = inItem.Item;
            if (inItem.Item.Name == target.Item.Name)
                ingredient.NeededAmount = ProcessStepTarget.Amount;
            else
                ingredient.NeededAmount = decimal.Round(multiplikator * inItem.Amount, 2, MidpointRounding.ToPositiveInfinity);
            balance.Add(ingredient);
        }

        return balance;
    }

    private ICollection<ItemBalanceModel> CalculateBalanceByProductTarget()
    {


        ICollection<ItemBalanceModel> balance = new HashSet<ItemBalanceModel>();

        ItemWithAmount target = Recipe.Byproducts.First(x => x.Item.Name == ProcessStepTarget.Item.Name);

        decimal standardmenge = target.Amount;
        decimal multiplikator = ProcessStepTarget.Amount / standardmenge;

        ItemBalanceModel MainProduct = new ItemBalanceModel();
        MainProduct.Item = Recipe.MainProduct.Item;
        MainProduct.ProducedAmount = decimal.Round(multiplikator * Recipe.MainProduct.Amount, 2, MidpointRounding.ToNegativeInfinity);

        balance.Add(MainProduct);


        foreach (ItemWithAmount bypitem in Recipe.Byproducts)
        {
            ItemBalanceModel byProduct = new ItemBalanceModel();
            byProduct.Item = bypitem.Item;
            if (bypitem.Item.Name == target.Item.Name)
                byProduct.ProducedAmount = ProcessStepTarget.Amount;
            else
                byProduct.ProducedAmount = decimal.Round(multiplikator * bypitem.Amount, 2, MidpointRounding.ToNegativeInfinity);
            balance.Add(byProduct);
        }

        foreach (ItemWithAmount inItem in Recipe.Ingredients)
        {
            ItemBalanceModel ingredient = new ItemBalanceModel();
            ingredient.Item = inItem.Item;
            ingredient.NeededAmount = decimal.Round(multiplikator * inItem.Amount, 2, MidpointRounding.ToPositiveInfinity);
            balance.Add(ingredient);
        }

        return balance;
    }


    private ICollection<ItemBalanceModel> CalculateBalanceWithoutTarget()
    {

        ICollection<ItemBalanceModel> balance = new HashSet<ItemBalanceModel>();

        balance.Add(new ItemBalanceModel() { Item = Recipe.MainProduct.Item });

        foreach (ItemWithAmount bypitem in Recipe.Byproducts)
        {
            balance.Add(new ItemBalanceModel() { Item = bypitem.Item });
        }

        foreach (ItemWithAmount inItem in Recipe.Ingredients)
        {
            balance.Add(new ItemBalanceModel() { Item = inItem.Item });
        }

        return balance;
    }
}
