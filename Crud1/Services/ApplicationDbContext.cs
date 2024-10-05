using Crud1.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud1.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Receipt> receipts { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
