using Calunsag_Final_IPT102.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Calunsag_Final_IPT102.Services
{
    public class CalunsagDbContext : IdentityDbContext<AppUser>
    {
        public CalunsagDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
