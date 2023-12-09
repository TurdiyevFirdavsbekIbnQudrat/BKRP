using Bogcha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bogcha.Infrastructure.Configuration
{
    public class TarbiyachiTypeConfiguration : IEntityTypeConfiguration<Tarbiyachi>
    {
        public void Configure(EntityTypeBuilder<Tarbiyachi> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x=>x.Familiya).HasMaxLength(40);

            builder.Property(x => x.Ism).IsRequired().HasMaxLength(40);
            builder.HasData(
                new Tarbiyachi { Id = 1, Ism = "Asilbek", Familiya = "Xolmatov" ,Password="tarbiyachi",UserName="Asilbek",role=Domain.Enums.Role.Tarbiyachi},
                new Tarbiyachi { Id = 2, Ism = "Azizbek", Familiya = "Xajiqurbonov", Password = "tarbiyachi", UserName = "Azizbek", role = Domain.Enums.Role.Tarbiyachi },
                new Tarbiyachi {Id = 3, Ism = "E'zoza", Familiya = "Turdiyeva", Password = "tarbiyachi", UserName = "E'zoza", role = Domain.Enums.Role.Tarbiyachi },
                new Tarbiyachi {Id = 4, Ism = "Mohigul", Familiya = "Matqosimova", Password = "tarbiyachi", UserName = "Mohigul", role = Domain.Enums.Role.Tarbiyachi }
                );
        }
    }
}
