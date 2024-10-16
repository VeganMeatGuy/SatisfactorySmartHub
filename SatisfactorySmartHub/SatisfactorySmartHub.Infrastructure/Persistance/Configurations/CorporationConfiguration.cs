using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal sealed class CorporationConfiguration : IdentityEntityBaseConfiguration<Corporation>
{
    public override void Configure(EntityTypeBuilder<Corporation> builder)
    {
        builder.Property(p => p.Name)
            .IsUnicode();

        builder.HasMany(e => e.Branches)
            .WithOne(e => e.Corporation)
            .HasForeignKey(e => e.CorporationId)
            .IsRequired(false);

        base.Configure(builder);
    }
}
