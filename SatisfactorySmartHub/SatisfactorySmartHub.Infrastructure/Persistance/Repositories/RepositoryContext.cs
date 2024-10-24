using Microsoft.EntityFrameworkCore;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories;

public sealed partial class RepositoryContext(DbContextOptions<RepositoryContext> contextOptions) : DbContext(contextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IInfrastructureAssemblyMarker).Assembly);

        modelBuilder.Entity<Recipe>().HasData(
            Recipe.Create(Guid.Parse("75121144-cdbf-4a3b-a859-ccf80d8664b6"), "Iron Plate").Value,
            Recipe.Create(Guid.Parse("05cd0d20-dc9d-4d5e-b798-4fcd4a9f90cc"), "Iron Rod").Value,
            Recipe.Create(Guid.Parse("a3e1febf-d514-43ab-a7d9-46297d5d4029"), "Wire").Value);
    }

    public override int SaveChanges()
    {
        int result = default;
        try
        {
            return base.SaveChanges();
        }
        catch (Exception ex)
        {

        }
        return result;
    }
}
