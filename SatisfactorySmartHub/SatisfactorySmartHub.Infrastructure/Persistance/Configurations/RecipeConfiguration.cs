using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal sealed class RecipeConfiguration : IdentityEntityBaseConfiguration<Recipe>
{
    public override void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(p => p.Name)
            .IsUnicode()
            .IsRequired();

        builder.Property(p => p.ProductionTime)
            .IsRequired();

        builder.HasOne(e =>e.Machine)
            .WithMany()
            .HasForeignKey(e => e.MachineId)
            .IsRequired();

        base.Configure(builder);
    }
}
