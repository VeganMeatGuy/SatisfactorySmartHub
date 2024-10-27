using Microsoft.EntityFrameworkCore;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Common;
using SatisfactorySmartHub.Infrastructure.Persistance.Data;
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

        modelBuilder.Entity<Machine>().HasData(StaticData.Machines);

        modelBuilder.Entity<Item>().HasData(StaticData.Items);

        modelBuilder.Entity<Ingredient>().HasData(
            Ingredient.Create(
                       Guid.Parse("eb936b9c-dc1c-45cf-9b71-c9155b1dd790"),
                       Guid.Parse("6b95911b-3711-470a-84ff-f843825eb3e6"),
                       Guid.Parse("6c944ca5-c6ba-4df4-a08e-c06134ba1472"),
                       1m).Value);

        modelBuilder.Entity<MainProduct>().HasData(
           MainProduct.Create(
                   Guid.Parse("5f075a56-f6a5-409f-bf92-0920edd02de1"),
                   Guid.Parse("6b95911b-3711-470a-84ff-f843825eb3e6"),
                   Guid.Parse("be5c74ec-52aa-400c-a1b4-3fd3ac9a5ee5"),
                   1).Value);


        modelBuilder.Entity<Recipe>().HasData(
           Recipe.Create(
               Guid.Parse("6b95911b-3711-470a-84ff-f843825eb3e6"),
               "Iron Ingot",
               Guid.Parse("629893a3-3ae2-408f-8af5-70bcea9c1d19")).Value);
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
