using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.Base;
using System.Linq.Expressions;
using System.Xml;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories;

internal class RecipeRepository(IServiceProvider serviceProvider) : IdentityRepository<Recipe>(serviceProvider), IRecipeRepository
{
    public IEnumerable<Recipe> GetAllEager()
    {
        var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();



        return context.Recipes
            .Include(recipe => recipe.Machine)
            .Include(recipe => recipe.Ingredients)
            .ThenInclude(ingredient => ingredient.Item)
            .Include(recipe => recipe.MainProduct)
            .ThenInclude(mainProduct => mainProduct.Item)
            .Include(recipe => recipe.ByProducts)
            .ThenInclude(byProduct => byProduct.Item)
            .ToList();

        //var dbset = context.Set<Recipe>();

        //return dbset;
          
    }
}
