using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

internal class ItemWithAmountBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IItemWithAmountBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(p => p.Amount);

        builder.HasOne(e => e.Item)
            .WithMany()
            .HasForeignKey(e => e.ItemId)
            .IsRequired(true);

    }
}
