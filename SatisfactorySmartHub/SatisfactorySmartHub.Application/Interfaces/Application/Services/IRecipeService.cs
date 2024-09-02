using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

/// <summary>
/// The recipe service interface.
/// </summary>
public interface IRecipeService
{

    /// <summary>
    /// Returns a collection of all available recipes.
    /// </summary>
    /// <returns><see cref="ICollection{T}"/></returns>
    ICollection<RecipeModel> GetAllRecipes();
}
