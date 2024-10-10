using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.Base;
using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;

public interface IItemRepository
{
    public IEnumerable<Item> GetAll();
    public Item? GetById(int id);
}
