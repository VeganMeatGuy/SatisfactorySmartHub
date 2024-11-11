using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal sealed class BranchConfiguration : IdentityEntityBaseConfiguration<Branch>
{
    public override void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.Property(p => p.Name)
            .IsUnicode();

        builder.HasOne(e => e.Corporation)
            .WithMany(e => e.Branches)
            .HasForeignKey(e => e.CorporationId)
            .IsRequired(false);

        base.Configure(builder);
    }
}
