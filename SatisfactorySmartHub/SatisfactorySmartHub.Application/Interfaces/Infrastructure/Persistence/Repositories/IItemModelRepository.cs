using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;

public interface IItemModelRepository
{
    IEnumerable<ItemModel> GetAll();
}
