using Bogcha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bogcha.Infrastructure.Configuration
{
    public class DavomatTypeConfiguration : IEntityTypeConfiguration<Davomat>
    {
        public void Configure(EntityTypeBuilder<Davomat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ishtirok).HasDefaultValue(0);
            builder.Property(x => x.BolaId).IsRequired();
            builder.HasData(
                new Davomat { Id = 1, BolaId = 1,ishtirok=1 },
                new Davomat { Id = 2, BolaId = 2, ishtirok = 2 },
                new Davomat { Id = 3, BolaId = 3, ishtirok = 3 },
                new Davomat { Id = 4, BolaId = 4, ishtirok = 4 }
                );
     
        }
    }
}
