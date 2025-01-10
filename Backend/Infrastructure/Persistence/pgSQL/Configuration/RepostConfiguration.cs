
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.pgSQL.Configuration;
public class RepostConfiguration : IEntityTypeConfiguration<Repost>
{
    public void Configure(EntityTypeBuilder<Repost> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PostId).IsRequired();
        builder.Property(x => x.UserId).IsRequired();
        
    }
}