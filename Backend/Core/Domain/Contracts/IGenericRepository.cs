using System.Linq.Expressions;
using Core.Domain.Entities;

namespace Core.Domain.Contracts;

public interface IGenericRepository<T> where T : DefaultEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Get all entities that match the predicate
    /// </summary>
    /// <param name="predicate">An expression Entity, bool</param>
    /// <returns>An awaitable list o entities</returns>
    Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task DeleteAsync(T Entity);
}