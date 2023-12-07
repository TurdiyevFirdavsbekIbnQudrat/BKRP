using Bogcha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bogcha.Infrastructure.Configuration
{
    public class GuruhTypeConfiguration : IEntityTypeConfiguration<Guruh>
    {
        public void Configure(EntityTypeBuilder<Guruh> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            
            builder.Property(x => x.GuruhName).IsRequired().HasMaxLength(40);
            builder.HasData(
             new Guruh { Id =1 ,GuruhName="Kamalak"},
             new Guruh { Id = 2, GuruhName = "Kapalak" }
                );
        }
    }
}
