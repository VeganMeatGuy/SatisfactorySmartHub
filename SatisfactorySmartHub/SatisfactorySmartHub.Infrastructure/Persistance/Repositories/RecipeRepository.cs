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
}
