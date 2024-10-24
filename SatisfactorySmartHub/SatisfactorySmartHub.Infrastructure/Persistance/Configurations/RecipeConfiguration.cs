using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Infrastructure.Persistance.Configurations.Base;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Configurations;

internal sealed class RecipeConfiguration : IdentityEntityBaseConfiguration<Recipe>
{
    public override void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(p => p.Name)
            .IsUnicode();

        base.Configure(builder);
    }
}
