using SatisfactorySmartHub.Application.Interfaces.Application.Services;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Services;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Services;

internal class ItemService(IRepositoryService repositoryService) : IItemService
{
    public IEnumerable<Item> GetItems()
    {
        try
        {
            return repositoryService.ItemRepository.GetAll();
        }
        catch
        {
            return new List<Item>();
        }
    }
}
