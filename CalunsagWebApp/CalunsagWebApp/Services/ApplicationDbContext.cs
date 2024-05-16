using CalunsagWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CalunsagWebApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
