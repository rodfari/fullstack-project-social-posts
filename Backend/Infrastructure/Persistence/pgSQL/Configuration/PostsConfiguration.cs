using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.pgSQL.Configuration;
public class PostsConfiguration : IEntityTypeConfiguration<Posts>
{
    public void Configure(EntityTypeBuilder<Posts> builder)
    {
        builder.ToTable("tb_posts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Content).HasMaxLength(777);
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorId);
        builder.HasOne(x => x.Reposts).WithMany().HasForeignKey(x => x.OriginalPostId);
    }
}