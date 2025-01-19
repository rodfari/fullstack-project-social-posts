using System.Linq.Expressions;
using Core.Domain.Entities;

namespace Core.Domain.Contracts;
public interface IPostsRepository: IGenericRepository<Posts>
{
    Task<int> CountAsync();
    Task<List<Posts>> GetAllAsync(
        Expression<Func<Posts, bool>>? predicate, 
        int Page,
        int PageSize,
        string sort, 
        bool trending);
    Task<Posts> GetPostAndUserByIdAsync(int id);
}