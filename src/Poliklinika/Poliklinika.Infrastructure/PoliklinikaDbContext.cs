
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Poliklinika.Application.Abstraction;
using Poliklinika.Domain.Entities;

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
        public virtual DbSet<Ishchi> Ishchilar { get; set; }
        public virtual DbSet<Admin> Adminlar { get; set; }
        public virtual DbSet<KunVaVaqt> kunVaqtlar { get ; set ; }
        public virtual DbSet<ShifokorIshKunlari> shifokorningIshKunlari { get ; set ; }
    }
}
