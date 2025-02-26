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

    public Task<int> CountAsync()
    {
        return _context.Posts.CountAsync();
    }

    public async Task<IEnumerable<Posts>> LoadTimeLineAsync(Expression<Func<Posts, bool>> predicate, int Page, int PageSize, string sort)
    {
        var query = _context.Posts
        .Where(predicate)
        .Include(p => p.User)
        .Include(p => p.Author).DefaultIfEmpty()
        .Include(p => p.Reposts).DefaultIfEmpty()
        .AsQueryable();

        //sort by trending
        if (sort.Equals("trending"))
        {
            query = query.Where(x => !x.IsRepost).OrderByDescending(x => x.RepostCount);
        }
        else
        {
            query = query.OrderByDescending(x => x.CreatedAt);
        }

        query = query.Skip((Page - 1) * PageSize).Take(PageSize);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<Posts> GetPostAndUserByIdAsync(int id)
    {
        return await _context.Posts.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == id);
    }
}