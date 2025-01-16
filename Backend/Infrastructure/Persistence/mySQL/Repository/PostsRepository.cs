using System.Linq.Expressions;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.mySQL.Repository;
public class PostsRepository : GenericRepository<Posts>, IPostsRepository
{
    public PostsRepository(DataContext context) : base(context)
    {
    }

    public async Task<List<Posts>> GetAllAsync(Expression<Func<Posts, bool>>? predicate, string sort, bool trending)
    {
        var query = _context.Posts.AsQueryable();

        sort = string.IsNullOrEmpty(sort) ? "desc" : sort;
        if (predicate != null)
        {
            query = query.Where(predicate);
        }
        if(sort.Equals("trending"))
        {
            //order by posts with most reposts
            query = query.OrderByDescending(p => p.RepostCount);
        }
        else if (sort == "asc")
        {
            query = query.OrderBy(p => p.CreatedAt);
        }
        else if (sort == "desc")
        {
            query = query.OrderByDescending(p => p.CreatedAt);
        }
        query = query
            .Include(p => p.User)
            .Include(p => p.Author)
            .Include(p => p.Reposts);
            
        return await query.AsNoTracking()
            .ToListAsync();
    }

    public async Task<Posts> GetPostAndUserByIdAsync(int id)
    {
        return await _context.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
    }
}