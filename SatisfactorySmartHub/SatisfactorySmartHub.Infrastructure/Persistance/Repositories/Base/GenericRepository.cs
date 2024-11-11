using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence.Repositories.Base;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Infrastructure.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SatisfactorySmartHub.Infrastructure.Persistence.Repositories.Base;

internal abstract class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
{
    protected IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
    /// </summary>
    /// <remarks>
    /// Any context that inherits from <see cref="DbContext"/> should work.
    /// </remarks>
    /// <param name="dbContext">The database context to work with.</param>
    protected GenericRepository(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public int Count(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IQueryable<T>>? queryFilter = null)
    {
        IQueryable<T> query =
            PrepareQuery(expression, queryFilter);

        return query.Count();
    }

    public void Create(T entity)
    {
        var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public void Create(IEnumerable<T> entities)
    {
        var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
        context.Set<T>().AddRange(entities);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }

    public void Delete(IEnumerable<T> entities)
    {
        var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
        context.Set<T>().RemoveRange(entities);
        context.SaveChanges();
    }

    public IEnumerable<T> GetAll(bool trackChanges = false)
    {
        IQueryable<T> query =
            PrepareQuery(trackChanges: trackChanges);

        return query.ToList();
    }

    public T? GetByCondition(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IQueryable<T>>? queryFilter = null, bool trackChanges = false, params string[] includeProperties)
    {
        IQueryable<T> query =
            PrepareQuery(expression, queryFilter, trackChanges: trackChanges, includeProperties: includeProperties);

        return query.SingleOrDefault();
    }

    public IEnumerable<T> GetManyByCondition(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IQueryable<T>>? queryFilter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int? take = null, int? skip = null, bool trackChanges = false, params string[] includeProperties)
    {
        IQueryable<T> query =
            PrepareQuery(expression, queryFilter, orderBy, take, skip, trackChanges, includeProperties);

        return query.ToList();
    }

    public int TotalCount()
    {
        IQueryable<T> query =
            PrepareQuery();

        return query.Count();
    }

    public void Update(T entity)
    {
        var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }


    public void Update(IEnumerable<T> entities)
    {
        var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
        context.Set<T>().UpdateRange(entities);
        context.SaveChanges();
    }

    protected IQueryable<T> PrepareQuery(
        Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IQueryable<T>>? queryFilter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int? take = null,
        int? skip = null,
        bool trackChanges = false,
        params string[] includeProperties)
    {

        var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
        var dbset = context.Set<T>();

        IQueryable<T> query = !trackChanges ? dbset.AsNoTracking() : dbset;

        if (expression is not null)
            query = query.Where(expression);

        if (queryFilter is not null)
            query = queryFilter(query);

        if (includeProperties.Length > 0)
            query = includeProperties.Aggregate(query, (theQuery, theInclude) => theQuery.Include(theInclude));

        if (orderBy is not null)
            query = orderBy(query);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        return query;

    }
}
