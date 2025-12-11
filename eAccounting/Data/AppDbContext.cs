using eAccounting.Models;
using Microsoft.EntityFrameworkCore;

namespace eAccounting.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    }
}
