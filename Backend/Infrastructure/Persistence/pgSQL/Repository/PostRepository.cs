using Core.Domain.Entities;
using Core.Domain.Contracts;
using Infrastructure.Persistence.Repository;

namespace Infrastructure.Persistence.pgSQL.Repository;
public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(DataContext context) : base(context)
    {
    }
}