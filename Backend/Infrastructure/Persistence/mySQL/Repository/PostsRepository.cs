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

    public async Task<List<Posts>> GetAllAsync(Expression<Func<Posts, bool>>? predicate, int Page, int PageSize, string sort, bool trending)
    {
        var query = _context.Posts.AsQueryable();


        if (predicate != null)
            query = query.Where(predicate);

        //sort by trending
        if (trending)
        {
            query = query.Where(x => !x.IsRepost).OrderByDescending(x => x.RepostCount);
        }
        else
        {
            query = sort switch
            {
                "asc" => query.OrderBy(x => x.CreatedAt),
                "desc" => query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderByDescending(x => x.CreatedAt)
            };
        }

        query = query
            .Include(p => p.User)
            .Include(p => p.Author)
            .Include(p => p.Reposts);

        query = query.Skip((Page - 1) * PageSize).Take(PageSize);

            return await query.AsNoTracking()
                .ToListAsync();
    }

    public async Task<Posts> GetPostAndUserByIdAsync(int id)
    {
        return await _context.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
    }
}