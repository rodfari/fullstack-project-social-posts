using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.pgSQL.Configuration
{
    public class DailyPostLimitConfiguration : IEntityTypeConfiguration<DailyPostLimit>
    {
        public void Configure(EntityTypeBuilder<DailyPostLimit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}