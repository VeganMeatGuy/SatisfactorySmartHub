using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal class ByProductConfiguration : ItemWithAmountBaseConfiguration<ByProduct>
{
    public override void Configure(EntityTypeBuilder<ByProduct> builder)
    {
        base.Configure(builder);
    }
}
