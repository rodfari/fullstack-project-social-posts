using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Domain.Contracts;
using Infrastructure.Persistence.Repository;

namespace Infrastructure.Persistence.pgSQL.Repository;
public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(DataContext context) : base(context)
    {
    }
}