using SatisfactorySmartHub.Domain.Interfaces.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.Base;

/// <summary>
/// The identity repository interface.
/// </summary>
/// <typeparam name="T">The type work with.</typeparam>
public interface IIdentityRepository<T> : IGenericRepository<T> where T : IIdentityEntityBase
{
    /// <summary>
    /// Returns an entity of type <typeparamref name="T"/> by its primary key.
    /// </summary>
    /// <param name="id">The primary key of the entity.</param>
    /// <param name="trackChanges">Should the fetched entity be tracked?</param>
    /// <returns>An entity of type <typeparamref name="T"/> or <see langword="null"/>.</returns>
    T? GetById(Guid id, bool trackChanges = false);

    /// <summary>
    /// Returns a collection of entites of type <typeparamref name="T"/> by their primary keys.
    /// </summary>
    /// <param name="ids">The primary keys of the entities.</param>
    /// <param name="trackChanges">Should the fetched entities be tracked?</param>
    /// <returns>A collection of entites of type <typeparamref name="T"/>.</returns>
    IEnumerable<T> GetByIds(IEnumerable<Guid> ids, bool trackChanges = false);
}
