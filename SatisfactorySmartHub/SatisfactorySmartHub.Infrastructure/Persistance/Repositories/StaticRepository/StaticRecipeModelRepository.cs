using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories.StaticRepository;

internal class StaticRecipeModelRepository : IRecipeModelRepository
{
    public IEnumerable<RecipeModel> GetAll()
    {
        return Recipes.RecipeList;
    }
}
