using System.Linq.Expressions;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.pgSQL.Repository;
public class PostsRepository : GenericRepository<Posts>, IPostsRepository
{
    public PostsRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<Posts>> GetAllAsync(Expression<Func<Posts, bool>>? predicate, string sort, bool trending)
    {
        var query = _context.Posts.Include(p => p.User).AsQueryable();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        if(trending)
        {
            //order by posts with most reposts
            query = query.OrderByDescending(p => p.RepostCount);
        }
        if (sort == "asc")
        {
            query = query.OrderBy(p => p.CreatedAt);
        }
        else if (sort == "desc")
        {
            query = query.OrderByDescending(p => p.CreatedAt);
        }

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<Posts> GetPostAndUserByIdAsync(int id)
    {
        return await _context.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
    }
}