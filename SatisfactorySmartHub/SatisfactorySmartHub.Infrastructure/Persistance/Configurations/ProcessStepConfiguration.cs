using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal sealed class ProcessStepConfiguration : IdentityEntityBaseConfiguration<ProcessStep>
{
    public override void Configure(EntityTypeBuilder<ProcessStep> builder)
    {
        builder.HasOne(e => e.Branch)
            .WithMany(e => e.ProcessSteps)
            .HasForeignKey(e => e.BranchId)
            .IsRequired(false);

        builder.HasOne(e => e.Recipe)
            .WithMany()
            .HasForeignKey(e => e.RecipeId)
            .IsRequired(false);

        builder.OwnsOne(p => p.Target, targetBuilder =>
        {
            targetBuilder.Property(m => m.ItemId).IsRequired();
            targetBuilder.Property(m => m.Amount).IsRequired();
        });

        builder.HasMany(e => e.ImplementedMachinery)
            .WithOne(e => e.ProcessStep)
            .HasForeignKey(e => e.ProcessStepId)
            .IsRequired(false);

        base.Configure(builder);
    }
}
