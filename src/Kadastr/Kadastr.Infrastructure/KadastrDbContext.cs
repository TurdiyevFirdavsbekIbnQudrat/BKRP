using Kadastr.Application.Abstraction;
using Kadastr.Domain.Entities;
using Kadastr.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
namespace Kadastr.Infrastructure
{
    public class KadastrDbContext : DbContext, IKadastrDbContext
    {
        public KadastrDbContext(DbContextOptions<KadastrDbContext> options) :
        base(options)
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
            modelBuilder.ApplyConfiguration(new RollarTypeConfiguration());
        }
        public virtual DbSet<Foydalanuvchi> Foydalanuvchilar { get; set; }
        public virtual DbSet<Rollar> Rollars { get; set; }
        public virtual DbSet<Yer> Yerlar { get; set; }
        public virtual DbSet<YerNarxi> YerNarxlar { get; set; }
        async ValueTask<int> IKadastrDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
