using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Infrastructure.Configuration
{
    public class KunVaVaqtTypeConfiguration : IEntityTypeConfiguration<KunVaVaqt>
    {
        public void Configure(EntityTypeBuilder<KunVaVaqt> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();

            builder.HasData(
             new KunVaVaqt { Kun=DateTime.Today.ToString(), ShifokorIshKunlarId = 1,Vaqt="9:30" },
             new KunVaVaqt { Kun = DateTime.Today.ToString(), ShifokorIshKunlarId = 2, Vaqt = "10:30" }
                );

        }
    }
}
