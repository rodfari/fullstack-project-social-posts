using Core.Domain.Entities;

namespace Core.Domain.Contracts;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task DeleteAsync(T Entity);
    Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);
}