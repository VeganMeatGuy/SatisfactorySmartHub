using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories;

internal class RecipeRepository(IServiceProvider serviceProvider) : IdentityRepository<Recipe>(serviceProvider),  IRecipeRepository
{
}
