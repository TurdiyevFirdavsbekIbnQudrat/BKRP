using Kadastr.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kadastr.Application.Abstraction
{
    public interface IKadastrDbContext
    {

        DbSet<Foydalanuvchi> Foydalanuvchilar { get; set; }
        DbSet<Rollar> Rollars { get; set; }
        DbSet<Yer> Yerlar { get; set; }
        DbSet<YerNarxi> YerNarxlar { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
