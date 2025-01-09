using Core.Domain.Entities;

namespace Core.Domain.Contracts;
public interface IPostRepository: IGenericRepository<Post>
{
    Task<List<Post>> GetPostsAndUserAsync();
}