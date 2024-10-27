using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal class MainProductConfiguration : ItemWithAmountBaseConfiguration<MainProduct>
{
    public override void Configure(EntityTypeBuilder<MainProduct> builder)
    {
        builder.HasKey(c => new { c.RecipeId, c.ItemId });

        builder.HasOne(e => e.Recipe)
            .WithOne(e => e.MainProduct)
            .HasForeignKey<MainProduct>(e => e.RecipeId)
            .IsRequired(false);
        
        base.Configure(builder);
    }
}
