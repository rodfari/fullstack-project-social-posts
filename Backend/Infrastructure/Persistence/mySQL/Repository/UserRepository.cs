
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Infrastructure.Persistence.Repository;

namespace Infrastructure.Persistence.mySQL.Repository;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}