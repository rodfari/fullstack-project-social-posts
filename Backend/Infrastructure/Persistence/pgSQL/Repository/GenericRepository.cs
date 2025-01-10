using System.Linq.Expressions;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Infrastructure.Persistence.pgSQL;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>x.Id == id) ?? Activator.CreateInstance<T>();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}