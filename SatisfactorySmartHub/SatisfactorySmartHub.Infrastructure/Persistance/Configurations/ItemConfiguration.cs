using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal sealed class ItemConfiguration : IdentityEntityBaseConfiguration<Item>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(p => p.Name)
            .IsUnicode();

        base.Configure(builder);
    }
}
