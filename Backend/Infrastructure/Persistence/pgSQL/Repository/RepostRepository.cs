using Core.Domain.Entities;
using Core.Domain.Contracts;
using Infrastructure.Persistence.Repository;

namespace Infrastructure.Persistence.pgSQL.Repository;

public class RepostRepository : GenericRepository<Repost>, IRepostRepository
{
    public RepostRepository(DataContext context) : base(context)
    {
    }
}
