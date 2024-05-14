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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var client = new IdentityRole("client");
            client.NormalizedName = "client";

            var seller = new IdentityRole("seller");
            seller.NormalizedName = "seller";

            builder.Entity<IdentityRole>().HasData(admin, client, seller);
        }
    }
}
