using System.Linq.Expressions;
using Core.Domain.Entities;

namespace Core.Domain.Contracts;
public interface IPostRepository: IGenericRepository<Post>
{
    Task<Post> GetPostsAndUserByPostIdAsync(int postId);
    Task<List<Post>> GetSortedPosts(string sort);
    Task<List<Post>> GetAllPostsAndUserAsync();
    Task<List<Post>> GetAllPostsAndUserAsync(Expression<Func<Post, bool>> predicate);
    Task<List<Post>> GetAllPostsAndUserAsync(Expression<Func<Post, bool>> predicate, string sort);
}