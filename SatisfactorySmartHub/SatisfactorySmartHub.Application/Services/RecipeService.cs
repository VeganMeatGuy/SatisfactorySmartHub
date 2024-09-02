using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;

/// <summary>
/// The recipe service class.
/// </summary>
internal sealed class RecipeService(IRepositoryService repositoryService) : IRecipeService
{
    public ICollection<RecipeModel> GetAllRecipes() 
        => repositoryService.StaticRecipeRepository.GetAll();

}
