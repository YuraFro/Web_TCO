using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_TCO.Models;

namespace Web_TCO.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "6da1d9c7-af63-421e-8688-3579c5a44861",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser 
            { 
                Id = "c99ac8b7-7e47-46c2-a47f-6451114b8c00",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "urafrolov0101@gmail.com",
                NormalizedEmail = "URAFROLOV0101@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "6da1d9c7-af63-421e-8688-3579c5a44861",
                UserId = "c99ac8b7-7e47-46c2-a47f-6451114b8c00"
            });


        }
    }
}
