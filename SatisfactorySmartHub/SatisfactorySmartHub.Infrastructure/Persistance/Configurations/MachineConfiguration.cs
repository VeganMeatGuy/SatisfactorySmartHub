using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal class MachineConfiguration : IdentityEntityBaseConfiguration<Machine>
{
    public override void Configure(EntityTypeBuilder<Machine> builder)
    {
        builder.Property(p => p.Name)
            .IsUnicode()
            .IsRequired();

        builder.Property(p => p.PowerConsumption)
            .IsRequired();

    }
}
