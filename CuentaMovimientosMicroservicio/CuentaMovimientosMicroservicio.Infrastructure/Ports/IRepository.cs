using CuentaMovimientosMicroservicio.Domain.Entities;
using System.Linq.Expressions;

namespace CuentaMovimientosMicroservicio.Infrastructure.Ports;

public interface IRepository<T> where T : DomainEntity
{
    Task<T> GetOneAsync(Guid id);
    Task<IEnumerable<T>> GetManyAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeStringProperties = "",
        bool isTracking = false);
    Task<T> AddAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null);    
    Task<List<T>> WhereAsync(Expression<Func<T, bool>>? filter = null);
    Task<List<T>> ToListAsync();
}
