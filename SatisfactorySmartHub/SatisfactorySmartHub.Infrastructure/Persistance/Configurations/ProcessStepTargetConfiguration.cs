using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal class ProcessStepTargetConfiguration : ItemWithAmountBaseConfiguration<ProcessStepTarget>
{
    public override void Configure(EntityTypeBuilder<ProcessStepTarget> builder)
    {
        base.Configure(builder);
    }
}
