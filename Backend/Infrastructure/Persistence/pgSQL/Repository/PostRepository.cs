using Core.Domain.Entities;
using Core.Domain.Contracts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.pgSQL.Repository;
public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(DataContext context) : base(context) {}
    public async Task<List<Post>> GetAllPostsAndUserAsync()
    {
        return await _context.Posts
            .Include(x => x.User)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Post>> GetAllPostsAndUserAsync(Expression<Func<Post, bool>> predicate = null, string sort = "desc")
    {
        var query = _context.Posts
            .Include(x => x.User)
            .Include(x => x.Reposts)
            .OrderByDescending(x => x.CreatedAt)
            .AsQueryable();

        if(predicate != null)
        {
            query = query.Where(predicate);
        }    

        if (sort == "trending")
        {
            query = query.OrderByDescending(x => x.Reposts.Count());
        }

        return await query.ToListAsync();

    }
}