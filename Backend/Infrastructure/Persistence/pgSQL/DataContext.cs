using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.pgSQL;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
    : base(options) { }
    public DbSet<Post> Post { get; set; }
    public DbSet<Repost> Repost { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Posts> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in base.ChangeTracker.Entries<DefaultEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.UpdatedAt = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.IsDeleted = false;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
