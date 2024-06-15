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
    private ItemWithAmount? _productionTarget;
    private ItemWithAmount? _intakeTarget;

    public RecipeModel Recipe
    {
        get => _recipe;
        set => _recipe = value;
    }

    public ItemWithAmount? ProductionTarget
    {
        get => _productionTarget;
    }

    public ItemWithAmount? IntakeTarget
    {
        get => _intakeTarget;
    }

    public void SetProductionTarget(ItemWithAmount targetItemWithAmount)
    {
        _intakeTarget = null;

        if (Recipe.MainProduct.Item.Name != targetItemWithAmount.Item.Name)
            throw new Exception("Item ist nicht als Hauptprodukt im Rezept vorhanden.");

        if (Decimal.Round(targetItemWithAmount.Amount, 2) != targetItemWithAmount.Amount)
            throw new Exception("Input Menge darf maximal zwei Kommastellen haben.");

        _productionTarget = targetItemWithAmount;
    }

    public void SetIntakteTarget(ItemWithAmount targetItemWithAmount)
    {

        _productionTarget = null;

        if (Recipe.Ingredients.Any(x => x.Item.Name == targetItemWithAmount.Item.Name)!)
            throw new Exception("Item ist nicht als Zutat im Rezept vorhanden.");

        if (Decimal.Round(targetItemWithAmount.Amount, 2) != targetItemWithAmount.Amount)
            throw new Exception("Input Menge darf maximal zwei Kommastellen haben.");

        _intakeTarget = targetItemWithAmount;
    }

    public ICollection<ItemBalanceModel> GetBalance()
    {

        if (ProductionTarget != null)
        {
            return CalculateBalanceProductionTarget();
        }

        else if (IntakeTarget != null)
        {

            return CalculateBalanceIntakeTarget();
        }
        else
            return CalculateBalanceWithoutTarget();

    }


    public ICollection<ItemBalanceModel> CalculateBalanceProductionTarget()
    {
        ICollection<ItemBalanceModel> balance = new HashSet<ItemBalanceModel>();

        decimal standardmenge = Recipe.MainProduct.Amount;
        decimal multiplikator = ProductionTarget.Amount / standardmenge;

        ItemBalanceModel MainProduct = new ItemBalanceModel();
        MainProduct.Item = Recipe.MainProduct.Item;
        MainProduct.ProducedAmount = ProductionTarget.Amount;

        balance.Add(MainProduct);


        foreach (ItemWithAmount bypitem in Recipe.Byproducts)
        {
            ItemBalanceModel byProduct = new ItemBalanceModel();
            byProduct.Item = bypitem.Item;
            byProduct.ProducedAmount = Decimal.Round(multiplikator * bypitem.Amount, 2, MidpointRounding.ToNegativeInfinity);
            balance.Add(byProduct);
        }

        foreach (ItemWithAmount inItem in Recipe.Ingredients)
        {
            ItemBalanceModel ingredient = new ItemBalanceModel();
            ingredient.Item = inItem.Item;
            ingredient.NeededAmount = Decimal.Round(multiplikator * inItem.Amount, 2, MidpointRounding.ToPositiveInfinity);
            balance.Add(ingredient);
        }

        return balance;
    }

    public ICollection<ItemBalanceModel> CalculateBalanceIntakeTarget()
    {

        return null;
    }

    public ICollection<ItemBalanceModel> CalculateBalanceWithoutTarget()
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
