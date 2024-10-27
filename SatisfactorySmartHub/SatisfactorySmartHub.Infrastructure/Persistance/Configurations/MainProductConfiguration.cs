using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal class MainProductConfiguration : ItemWithAmountBaseConfiguration<MainProduct>
{
    public override void Configure(EntityTypeBuilder<MainProduct> builder)
    {
        base.Configure(builder);
    }
}
