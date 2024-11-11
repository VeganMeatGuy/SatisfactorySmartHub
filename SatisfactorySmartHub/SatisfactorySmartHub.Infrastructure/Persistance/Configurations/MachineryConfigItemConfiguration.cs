using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal sealed class MachineryConfigItemConfiguration : IdentityEntityBaseConfiguration<MachineryConfigItem>
{
    public override void Configure(EntityTypeBuilder<MachineryConfigItem> builder)
    {
        builder.Property(p => p.Quantity)
            .IsRequired();

        builder.Property(p => p.ClockSpeed) 
            .IsRequired();

        builder.HasOne(e => e.ProcessStep)
            .WithMany(e => e.ImplementedMachinery)
            .HasForeignKey(e => e.ProcessStepId)
            .IsRequired(false);

        base.Configure(builder);
    }
}
