using Core.Domain.Contracts;
using Core.Domain.Entities;
using Infrastructure.Persistence.Repository;

namespace Infrastructure.Persistence.pgSQL.Repository;
public class DailyPostLimitRepository : GenericRepository<DailyPostLimit>, IDailyPostLimitRepository
{
    public DailyPostLimitRepository(DataContext context) : base(context)
    {
    }
}