using Microsoft.EntityFrameworkCore;
using Poliklinika.Domain.Entities;

namespace Poliklinika.Application.Abstraction
{
    public interface IPoliklinikaDbContext
    {
         DbSet<Ishchi> Ishchilar { get; set; }
         DbSet<KunVaVaqt> kunVaqtlar {  get; set; }
         DbSet<ShifokorIshKunlari> shifokorningIshKunlari { get; set; }
         DbSet<Admin> Adminlar { get; set; }
         Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
