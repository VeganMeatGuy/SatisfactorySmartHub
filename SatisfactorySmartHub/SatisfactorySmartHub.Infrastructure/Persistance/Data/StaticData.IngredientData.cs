using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Data;

internal static partial class StaticData
{
    internal static class IngredientData
    {
        internal static IReadOnlyList<Ingredient> Ingredients => _ingredients;

        private static readonly IReadOnlyList<Ingredient> _ingredients =
            new List<Ingredient>()
            {
                Ingredient.Create(RecipeData.IronIngot.Id, ItemData.IronOre.Id, 1m).Value,
                Ingredient.Create(RecipeData.IronPlate.Id, ItemData.IronIngot.Id, 3m).Value
            };
    }
}
