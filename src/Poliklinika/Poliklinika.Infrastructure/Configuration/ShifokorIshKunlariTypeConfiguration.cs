using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Infrastructure.Configuration
{
    public class ShifokorIshKunlariTypeConfiguration : IEntityTypeConfiguration<ShifokorIshKunlari>
    {
        public void Configure(EntityTypeBuilder<ShifokorIshKunlari> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Dushanba).HasMaxLength(5).IsRequired();
            builder.Property(x => x.Seshanba).HasMaxLength(5).IsRequired();
            builder.Property(x => x.Chorshanba).HasMaxLength(5).IsRequired();
            builder.Property(x => x.Payshanba).HasMaxLength(5).IsRequired();
            builder.Property(x => x.Juma).HasMaxLength(5).IsRequired();
            builder.Property(x => x.Shanba).HasMaxLength(5).IsRequired();
            builder.HasData
                (
                new ShifokorIshKunlari 
                { Dushanba = "08:00", 
                  Seshanba = "08:00", 
                  Chorshanba = "09:00",
                  Payshanba = "13:00",
                  Juma = "13:00",
                  Shanba = "08:30",
                  IshchId=1
                }, 
                new ShifokorIshKunlari
                {
                    Dushanba = "10:00",
                    Seshanba = "09:00",
                    Chorshanba = "09:00",
                    Payshanba = "13:00",
                    Juma = "13:00",
                    Shanba = "08:30",
                    IshchId = 2
                }
                );


        }
    }
}
