using Bogcha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bogcha.Infrastructure.Configuration
{
    public class AdminTypeConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(
                new Admin() { Id=1,Password="Admin" , UserName = "Admin",Role="Admin"},
                new Admin() { Id=2,Password="Tarbiyachi",UserName="Tarbiyachi",Role="Tarbiyachi"}
             );
        }
    }
}
