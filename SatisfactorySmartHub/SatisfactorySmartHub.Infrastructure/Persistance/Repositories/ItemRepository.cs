using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Data;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories
{
    internal class ItemRepository() : IItemRepository
    {
        public IEnumerable<Item> GetAll()
        {
            return StaticData.Items;
        }

        public Item? GetById(int id)
        {
            Item? result = StaticData.Items.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
