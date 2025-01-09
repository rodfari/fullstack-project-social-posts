
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.pgSQL.Configuration;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Content).IsRequired().HasMaxLength(500);
        builder.Property(p => p.UserId).IsRequired();
        builder.HasOne(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId);
    }
}