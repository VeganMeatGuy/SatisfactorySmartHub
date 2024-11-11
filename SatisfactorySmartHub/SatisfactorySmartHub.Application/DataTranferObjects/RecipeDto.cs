using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

public sealed record RecipeDto(Guid Id, string Name, MachineDto Machine, decimal ProductionTime, IReadOnlyList<ItemWithAmountDto> Ingredients, ItemWithAmountDto MainProduct, IReadOnlyList<ItemWithAmountDto> ByProducts)
{
    internal static RecipeDto CreateFromEntity(Recipe recipe)
    {
        List<ItemWithAmountDto> tempIngredients = new();
        foreach (var ingredient in recipe.Ingredients)
            tempIngredients.Add(ItemWithAmountDto.CreateFromEntity(ingredient));

        List<ItemWithAmountDto> tempByproducts = new();
        foreach (var byProduct in recipe.ByProducts)
            tempByproducts.Add(ItemWithAmountDto.CreateFromEntity(byProduct));

        return new(
            recipe.Id,
            recipe.Name,
            MachineDto.CreateFromEntity(recipe.Machine),
            recipe.ProductionTime,
            tempIngredients,
            ItemWithAmountDto.CreateFromEntity(recipe.MainProduct),
            tempByproducts
        );
    }
}
