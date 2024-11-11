using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Ingredient : ItemWithAmountBase
{
    //empty constructor for EF Core
    private Ingredient() { }

    //foreign key
    public Guid RecipeId { get; private set; }

    //navigational properties
    public Recipe Recipe { get; private set; }

    public static ErrorOr<Ingredient> Create(Guid recipeId, Guid itemId, decimal amount)
    {
        var ingredient = new Ingredient
        {
            RecipeId = recipeId,
            ItemId = itemId,
            Amount = amount
        };
        return ingredient;
    }
}
