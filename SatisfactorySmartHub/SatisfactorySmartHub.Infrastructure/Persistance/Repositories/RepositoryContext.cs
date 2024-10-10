using Microsoft.EntityFrameworkCore;
using SatisfactorySmartHub.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories;

public sealed partial class RepositoryContext(DbContextOptions<RepositoryContext> contextOptions) : DbContext(contextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IInfrastructureAssemblyMarker).Assembly);
    }

    public override int SaveChanges()
    {
        int result = default;
        try
        {
            return base.SaveChanges();
        }
        catch (Exception ex)
        {

        }
        return result;
    }
}
