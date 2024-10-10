using Microsoft.EntityFrameworkCore;
using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories
{
    public sealed partial class RepositoryContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
    }
}
