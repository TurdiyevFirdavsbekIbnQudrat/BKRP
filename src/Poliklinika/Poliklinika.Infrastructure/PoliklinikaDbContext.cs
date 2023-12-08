
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Poliklinika.Application.Abstraction;
using Poliklinika.Domain.Entities;
using Poliklinika.Infrastructure.Configuration;

namespace Poliklinika.Infrastructure
{
    public class PoliklinikaDbContext : DbContext,IPoliklinikaDbContext
    {
        public PoliklinikaDbContext(DbContextOptions<PoliklinikaDbContext> options):
        base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect())  databaseCreator.CreateAsync();
                    if (!databaseCreator.HasTables())  databaseCreator.CreateTablesAsync();
                }
        }
        async ValueTask<int> IPoliklinikaDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IshchiTypeConfiguration());
            modelBuilder.ApplyConfiguration(new KunVaVaqtTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShifokorIshKunlariTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CreateAdminConfiguration());
            
        }
        public virtual DbSet<Ishchi> Ishchilar { get; set; }
        public virtual DbSet<Admin> Adminlar { get; set; }
        public virtual DbSet<KunVaVaqt> kunVaqtlar { get ; set ; }
        public virtual DbSet<ShifokorIshKunlari> shifokorningIshKunlari { get ; set ; }
    }
}
