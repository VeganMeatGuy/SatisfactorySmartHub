using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Data;

internal static partial class StaticData
{
    internal class RecipeData
    {
        internal static IReadOnlyList<Recipe> Recipes => _recipes;

        private static readonly IReadOnlyList<Recipe> _recipes =
            new List<Recipe>()
            {
                IronIngot,
                IronPlate
            };

        internal static Recipe IronIngot => Recipe.Create(
                   Guid.Parse("6b95911b-3711-470a-84ff-f843825eb3e6"),
                   "Iron Ingot", MachineData.Smelter.Id).Value;

        internal static Recipe IronPlate => Recipe.Create(
           Guid.Parse("34f401c1-1fbf-4d31-aff2-f04fa40f1831"),
           "Iron Plate", MachineData.Constructor.Id).Value;
    }
}
