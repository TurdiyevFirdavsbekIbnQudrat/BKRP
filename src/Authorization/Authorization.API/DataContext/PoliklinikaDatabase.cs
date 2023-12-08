using Authorization.API.Models.PoliklinikaModel;
using Microsoft.EntityFrameworkCore;

namespace Authorization.API.DataContext
{
    public class PoliklinikaDatabase: DbContext
    {

        public PoliklinikaDatabase(DbContextOptions<PoliklinikaDatabase> options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
    }
}
