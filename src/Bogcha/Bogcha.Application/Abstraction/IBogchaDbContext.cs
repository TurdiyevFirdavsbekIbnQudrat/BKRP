using Bogcha.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bogcha.Application.Abstraction
{
    public interface IBogchaDbContext
    {
        DbSet<Bola> Bolalar { get; set; }
        DbSet<Tarbiyachi> Tarbiyachilar { get; set; }
        DbSet<Guruh> Guruhlar { get; set; }
        DbSet<Davomat> Davomatlar { get; set; }
        DbSet<Admin> Adminlar { get; set; }
        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
