using Bogcha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bogcha.Infrastructure.Configuration
{
    public class BolaTypeConfiguration : IEntityTypeConfiguration<Bola>
    {
        public void Configure(EntityTypeBuilder<Bola> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Ism).IsRequired().HasMaxLength(40);
            builder.HasData(
                new Bola { Id = 1, Ism = "Yusuf", Familiya = "Turdiyev"},
                new Bola { Id = 2, Ism = "Sardor", Familiya = "Usmonov"},
                new Bola { Id = 3, Ism = "Iymona", Familiya = "Rustamova"},
                new Bola { Id = 4, Ism = "Po'latXo'ja", Familiya = "Xoldorxonov" }
                );

        }
    }
}
