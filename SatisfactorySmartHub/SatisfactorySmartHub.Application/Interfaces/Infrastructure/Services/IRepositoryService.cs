using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;

public interface IRepositoryService
{
    IRecipeModelRepository RecipeModelRepository { get; }
}
