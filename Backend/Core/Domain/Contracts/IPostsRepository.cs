using System.Linq.Expressions;
using Core.Domain.Entities;

namespace Core.Domain.Contracts;
public interface IPostsRepository: IGenericRepository<Posts>
{
    Task<List<Posts>> GetAllAsync(Expression<Func<Posts, bool>>? predicate, string sort, bool trending);
}