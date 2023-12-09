using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poliklinika.Domain.Entities;
using Poliklinika.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Infrastructure.Configuration
{
    public class CreateAdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(
                new Admin()
                {
                    Id = 1,
                    Parol = "string",
                    role = Role.Admin,
                    Username = "string"
                }
                );
        }
    }
}
