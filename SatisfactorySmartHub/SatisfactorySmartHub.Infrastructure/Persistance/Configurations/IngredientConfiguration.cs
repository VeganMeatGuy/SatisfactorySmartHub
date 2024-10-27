using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations; 

internal class IngredientConfiguration : ItemWithAmountBaseConfiguration<Ingredient>
{
    public override void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(c => new { c.RecipeId, c.ItemId });

        builder.HasOne(e => e.Recipe)
            .WithMany(e => e.Ingredients)
            .HasForeignKey(e => e.RecipeId)
            .IsRequired(false);

        base.Configure(builder);
    }
}
