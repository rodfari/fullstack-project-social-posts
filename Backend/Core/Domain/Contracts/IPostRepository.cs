using System.Linq.Expressions;
using Core.Domain.Entities;

namespace Core.Domain.Contracts;
public interface IPostRepository: IGenericRepository<Post>
{
    Task<List<Post>> GetAllPostsAndUserAsync();
    Task<List<Post>> GetAllPostsAndUserAsync(Expression<Func<Post, bool>> predicate, string sort);
}