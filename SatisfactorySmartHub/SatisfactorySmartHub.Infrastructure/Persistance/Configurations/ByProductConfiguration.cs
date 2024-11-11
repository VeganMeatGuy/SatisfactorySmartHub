using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal class ByProductConfiguration : ItemWithAmountBaseConfiguration<ByProduct>
{
    public override void Configure(EntityTypeBuilder<ByProduct> builder)
    {
        builder.HasKey(c => new { c.RecipeId, c.ItemId });

        builder.HasOne(e => e.Recipe)
            .WithMany(e => e.ByProducts)
            .HasForeignKey(e => e.RecipeId)
            .IsRequired(false);

        base.Configure(builder);
    }
}
