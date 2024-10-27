using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class MainProduct : ItemWithAmountBase
{
    //empty constructor for EF Core
    private MainProduct() { }

    //foreign key
    public Guid RecipeId { get; private set; }

    //navigational properties
    public Recipe Recipe { get; private set; }
    public static ErrorOr<MainProduct> Create(Guid id, Guid recipeId, Guid itemId, decimal amount)
    {
        var mainProduct = new MainProduct
        {
            Id = id,
            RecipeId = recipeId,
            ItemId = itemId,
            Amount = amount
        };
        return mainProduct;
    }
}
