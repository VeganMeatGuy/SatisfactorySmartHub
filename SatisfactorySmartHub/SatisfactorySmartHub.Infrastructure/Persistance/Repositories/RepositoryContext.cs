using Microsoft.EntityFrameworkCore;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Common;
using SatisfactorySmartHub.Infrastructure.Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SatisfactorySmartHub.Infrastructure.Persistance.Data.StaticData;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories;

public sealed partial class RepositoryContext(DbContextOptions<RepositoryContext> contextOptions) : DbContext(contextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IInfrastructureAssemblyMarker).Assembly);

        modelBuilder.Entity<Machine>().HasData(MachineData.Machines);

        modelBuilder.Entity<Item>().HasData(ItemData.Items);

        modelBuilder.Entity<Recipe>().HasData(RecipeData.Recipes);

        modelBuilder.Entity<Ingredient>().HasData(IngredientData.Ingredients);

        modelBuilder.Entity<MainProduct>().HasData(MainProductData.MainProducts);

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
