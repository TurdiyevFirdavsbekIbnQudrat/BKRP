using Bogcha.Application.Abstraction;
using Bogcha.Domain.Entities;
using Bogcha.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bogcha.Infrastructure
{
    public class BogchaDbContext:DbContext,IBogchaDbContext
    {
        public BogchaDbContext(DbContextOptions<BogchaDbContext> options) : base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (databaseCreator != null)
            {
                if (!databaseCreator.CanConnect()) databaseCreator.CreateAsync();
                if (!databaseCreator.HasTables()) databaseCreator.CreateTablesAsync();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BolaTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TarbiyachiTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DavomatTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AdminTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GuruhTypeConfiguration());
        }

        async ValueTask<int> IBogchaDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public    DbSet<Admin> Adminlar { get; set; }
        public     DbSet<Bola> Bolalar { get; set; }
        public     DbSet<Tarbiyachi> Tarbiyachilar { get; set; }
        public     DbSet<Guruh> Guruhlar { get; set; }
        public     DbSet<Davomat> Davomatlar { get; set; }
        
    }
}
