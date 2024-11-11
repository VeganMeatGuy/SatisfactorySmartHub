using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

internal sealed class RecipeDto : IRecipeDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public MachineDto Machine { get; init; }

    public IReadOnlyList<ItemWithAmountDto> Ingredients { get; init; } = new List<ItemWithAmountDto>();

    public ItemWithAmountDto MainProduct { get; init; }

    public IReadOnlyList<ItemWithAmountDto> ByProducts { get; init; } = new List<ItemWithAmountDto>();

    internal static RecipeDto CreateFromEntity(Recipe recipe)
    {
        List<ItemWithAmountDto> tempIngredients = new();
        foreach (var ingredient in recipe.Ingredients)
            tempIngredients.Add(ItemWithAmountDto.CreateFromEntity(ingredient));

        List<ItemWithAmountDto> tempByproducts = new();
        foreach (var byProduct in recipe.ByProducts)
            tempByproducts.Add(ItemWithAmountDto.CreateFromEntity(byProduct));

        return new()
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Machine = MachineDto.CreateFromEntity(recipe.Machine),
            Ingredients = tempIngredients,
            MainProduct = ItemWithAmountDto.CreateFromEntity(recipe.MainProduct),
            ByProducts = tempByproducts
        };
    }
}
