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
        public DbSet<Branch> Branches { get; set; }
        public DbSet<ByProduct> ByProducts { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineryConfigItem> MachineConfigItems { get; set; }
        public DbSet<MainProduct> MainProducts { get; set; }
        public DbSet<ProcessStep> ProcessSteps { get; set; }
        public DbSet<ProcessStepTarget> ProcessStepTargets { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
