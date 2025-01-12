using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.pgSQL.Configuration;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Content).HasMaxLength(777);
        builder.Property(p => p.UserId).IsRequired();
        builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId);
        builder.HasMany(rp => rp.Reposts).WithOne(p => p.Post).HasForeignKey(rp => rp.PostId);
    }
}