using Core.Domain.Entities;

namespace Core.Domain.Contracts;
public interface IPostRepository: IGenericRepository<Post>
{
    Task<List<Post>> GetAllPostsAndUserAsync();
    Task<Post> GetPostsAndUserByPostIdAsync(int postId);
}