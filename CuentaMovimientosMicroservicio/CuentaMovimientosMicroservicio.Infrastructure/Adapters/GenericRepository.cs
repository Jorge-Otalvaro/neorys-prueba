using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Infrastructure.DataSource;
using CuentaMovimientosMicroservicio.Infrastructure.Ports;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CuentaMovimientosMicroservicio.Infrastructure.Adapters;

public class GenericRepository<T> : IRepository<T> where T : DomainEntity
{
    readonly DataContext Context;
    readonly DbSet<T> _dataset;

    public GenericRepository(DataContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        _dataset = Context.Set<T>();
    }


    public async Task<IEnumerable<T>> GetManyAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeStringProperties = "", bool isTracking = false)
    {
        IQueryable<T> query = Context.Set<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(includeStringProperties))
        {
            foreach (var includeProperty in includeStringProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync().ConfigureAwait(false);
        }

        return (!isTracking) ? await query.AsNoTracking().ToListAsync() : await query.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity), "Entity can not be null");
        await _dataset.AddAsync(entity);        
        return entity;
    }

    public void DeleteAsync(T entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity), "Entity can not be null");
        _dataset.Remove(entity);        
    }

    public async Task<T> GetOneAsync(Guid id)
    {
        return await _dataset.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));

    }

    public void UpdateAsync(T entity)
    {
        _dataset.Update(entity);        
    }

    public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = Context.Set<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<T>> WhereAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = Context.Set<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }

    public async Task<List<T>> ToListAsync()
    {
        return await _dataset.ToListAsync();
    }
}
