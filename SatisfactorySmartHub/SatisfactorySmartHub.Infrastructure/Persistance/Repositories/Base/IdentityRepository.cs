using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.Base;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Repositories.Base;

internal abstract class IdentityRepository<T> : GenericRepository<T>, IIdentityRepository<T> where T : IdentityEntityBase
{
    /// <summary>
	/// Initializes an instance of <see cref="IdentityRepository{T}"/> class.
	/// </summary>
	/// <inheritdoc/>
	protected IdentityRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    { }

    public T? GetById(Guid id, bool trackChanges = false)
    {
        IQueryable<T> query =
            PrepareQuery(x => x.Id.Equals(id), trackChanges: trackChanges);

        return query.SingleOrDefault();
    }

    public IEnumerable<T> GetByIds(IEnumerable<Guid> ids, bool trackChanges = false)
    {
        IQueryable<T> query =
            PrepareQuery(x => ids.Contains(x.Id), trackChanges: trackChanges);

        return query.ToList();
    }
}
