using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;

public interface IItemService
{
    IEnumerable<Item> GetItems();
}
