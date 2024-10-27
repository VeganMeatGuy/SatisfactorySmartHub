using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal class ProcessStepTargetConfiguration : ItemWithAmountBaseConfiguration<ProcessStepTarget>
{
    public override void Configure(EntityTypeBuilder<ProcessStepTarget> builder)
    {
        builder.HasKey(c => new { c.ProcessStepId, c.ItemId });


        builder.HasOne(e => e.ProcessStep)
            .WithOne(e => e.Target)
            .HasForeignKey<ProcessStepTarget>(e => e.ProcessStepId)
            .IsRequired(false);

        base.Configure(builder);
    }
}
