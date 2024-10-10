using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

internal class IdentityEntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IIdentityEntityBase
{
    protected const string TableSchema = "private";
    protected const string HistorySchema = "history";

    /// <inheritdoc/>
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }
}
