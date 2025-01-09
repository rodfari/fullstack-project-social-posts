using Core.Domain.Contracts;
using Core.Domain.Entities;
using Infrastructure.Persistence.pgSQL;

namespace Infrastructure.Persistence.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly DataContext _context;
    public GenericRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var refe = await _context.FindAsync<T>(id);
        _context.Remove(refe);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T Entity)
    {

        _context.Remove(Entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
    {
        return _context.Set<T>().Where(predicate).AsEnumerable();

    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return  _context.Set<T>().AsEnumerable();
    }

    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}