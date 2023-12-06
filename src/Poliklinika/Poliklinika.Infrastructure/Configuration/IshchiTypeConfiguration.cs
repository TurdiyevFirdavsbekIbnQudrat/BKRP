using Microsoft.EntityFrameworkCore;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Infrastructure.Configuration
{
    public class IshchiTypeConfiguration : IEntityTypeConfiguration<Ishchi>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ishchi> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.XonaNomi).IsRequired();
            builder.Property(x => x.Ism).IsRequired();
            builder.HasData(
                new Ishchi {Id=1, Ism = "Firdavs", Familiya = "Turdiyev", Lavozimi = "Jarroh", XonaNomi = "22-xona" },
                new Ishchi {Id=2, Ism = "Po'latjon", Familiya = "Usmonov", Lavozimi = "Robiolog", XonaNomi = "23-xona" }
                );


        }
    }
}
