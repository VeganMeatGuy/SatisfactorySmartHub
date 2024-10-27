using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal sealed class RecipeConfiguration : IdentityEntityBaseConfiguration<Recipe>
{
    public override void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(p => p.Name)
            .IsUnicode();

        builder.HasMany(e => e.Ingredients)
            .WithOne(e => e.Recipe)
            .HasForeignKey(e => e.RecipeId)
            .IsRequired(false);

        builder.HasOne(e => e.MainProduct)
            .WithOne(e => e.Recipe)
            .HasForeignKey<MainProduct>(e => e.RecipeId)
            .IsRequired();

        builder.HasMany(e => e.ByProducts)
            .WithOne(e => e.Recipe)
            .HasForeignKey(e => e.RecipeId)
            .IsRequired(false);

        builder.HasOne(e =>e.Machine)
            .WithMany()
            .HasForeignKey(e => e.MachineId)
            .IsRequired();

        base.Configure(builder);
    }
}
