using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Domain.Contracts;
using Infrastructure.Persistence.Repository;

namespace Infrastructure.Persistence.pgSQL.Repository;

public class RepostRepository : GenericRepository<Repost>, IRepostRepository
{
    public RepostRepository(DataContext context) : base(context)
    {
    }
}
