using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.mySQL.Configuration;
public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("tb_users");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Username)
            .IsRequired();
            
        builder.HasIndex(x => x.Username).IsUnique();
    }
    
}