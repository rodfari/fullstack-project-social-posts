using System.Linq.Expressions;
using Core.Domain.Entities;

namespace Core.Domain.Contracts;
public interface IPostRepository: IGenericRepository<Post>
{
    Task<List<Post>> GetAllPostsAndUserAsync();
    Task<List<Post>> GetAllPostsAndUserAsync(Expression<Func<Post, bool>> predicate);
    Task<List<Post>> GetAllPostsAndUserAsync(Expression<Func<Post, bool>> predicate, string sort);
    
    /// <summary>
    /// Retrieves a post along with its associated user based on the specified post ID.
    /// </summary>
    /// <param name="postId">The ID of the post to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the post and its associated user.</returns>
    Task<Post> GetPostAndUserByPostIdAsync(int postId);

    
    /// <summary>
    /// Retrieves a post along with its associated user that matches the specified predicate.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the post and its associated user that matches the specified predicate.</returns>
    Task<Post> GetPostAndUserAsync(Expression<Func<Post, bool>> predicate);
}