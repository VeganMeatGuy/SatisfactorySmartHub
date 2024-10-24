using SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;
using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.DataTranferObjects;

internal sealed class RecipeDto :IRecipeDto
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;

    internal static RecipeDto CreateFromEntity(Recipe recipe)
    {
        return new() { Id = recipe.Id, Name = recipe.Name };
    }
}
