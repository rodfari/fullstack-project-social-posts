using Backend.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence.pgSQL;

public class PgSqlContext : DbContext
{
    public PgSqlContext(DbContextOptions<PgSqlContext> options) : base(options) { }
    public DbSet<Post> Posts { get; set; }
    public DbSet<DailyPostLimit> DailyPostLimit { get; set; }
    public DbSet<Repost> Repost { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PgSqlContext).Assembly);
    }
}
