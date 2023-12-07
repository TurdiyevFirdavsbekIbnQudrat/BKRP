using Kadastr.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadastr.Infrastructure.Configuration
{
    public class RollarTypeConfiguration : IEntityTypeConfiguration<Rollar>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Rollar> builder)
        {
            builder.HasData(
                new Rollar() { Id = 1, Parol = "12345678", Role = "Admin", UserName = "BoshAdmin" },
                new Rollar() { Id = 2, Parol = "12345678", Role = "Admin", UserName = "YordamchiAdmin" });
        }
    }
}
