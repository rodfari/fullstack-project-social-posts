using Core.Domain.Entities;
using Core.Domain.Contracts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.pgSQL.Repository;
public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(DataContext context) : base(context)
    {

    }

    public async Task<List<Post>> GetAllPostsAndUserAsync()
    {
        return await _context.Posts
            .Include(x => x.User)
            .OrderByDescending(x => x.CreatedAt).ToListAsync();
    }

    public async Task<List<Post>> GetAllPostsAndUserAsync(Expression<Func<Post, bool>> predicate)
    {
        return await _context.Posts
        .Include(x => x.User)
            .Where(predicate).ToListAsync();
    }


    public async Task<Post> GetPostsAndUserByPostIdAsync(int postId)
    {
        return await _context.Posts
            .Include(x => x.User).FirstOrDefaultAsync(x => x.Id == postId);
    }

    public async Task<List<Post>> GetSortedPosts(string sort)
    {
        if (sort == "latest")
        {
            return await _context.Posts
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
        return await _context.Posts
        .Where(x => x.IsRepost == false)
        .OrderByDescending(x => x.RepostCount)
        .ThenByDescending(x => x.CreatedAt)
        .ToListAsync();

    }
}