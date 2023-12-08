using Authorization.API.Models.BogchaModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Authorization.API.DataContext
{
    public class BogchaDatabase:DbContext
    {
        public BogchaDatabase(DbContextOptions<BogchaDatabase> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Tarbiyachi> Teachers { get; set; }
    }
}
