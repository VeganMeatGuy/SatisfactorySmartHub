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

        builder.HasMany(e => e.ImplementedMachinery)
            .WithOne(e => e.ProcessStep)
            .HasForeignKey(e => e.ProcessStepId)
            .IsRequired(false);

        base.Configure(builder);
    }
}
