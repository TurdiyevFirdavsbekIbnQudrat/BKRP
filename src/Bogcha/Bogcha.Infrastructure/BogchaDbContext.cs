using Bogcha.Application.Abstraction;
using Bogcha.Domain.Entities;
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
        public virtual    DbSet<Bola> Bolalar { get; set; }
        public virtual    DbSet<Tarbiyachi> Tarbiyachilar { get; set; }
        public virtual    DbSet<Guruh> Guruhlar { get; set; }
        public virtual    DbSet<Davomat> Davomatlar { get; set; }
    }
}
