using Core.Domain.Entities;
using Core.Domain.Contracts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.pgSQL.Repository;
public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(DataContext context) : base(context)
    {

    }

    public async Task<List<Post>> GetAllPostsAndUserAsync()
    {
        return await _context.Posts
            .Include(x =>x.User)
            .OrderByDescending(x => x.CreatedAt).ToListAsync();
    }

    public async Task<Post> GetPostsAndUserByPostIdAsync(int postId)
    {
        return await _context.Posts
            .Include(x =>x.User).FirstOrDefaultAsync(x => x.Id == postId);
    }
}