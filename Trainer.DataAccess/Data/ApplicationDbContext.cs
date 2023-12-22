using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trainer.Models;

namespace Trainer.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Tamer> Tamers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tamer>().HasData(
                new Tamer { Id = 1, Name = "Marcus", Country = "India" },
                new Tamer { Id = 2, Name = "Thomas", Country = "England" },
                new Tamer { Id = 3, Name = "Lily", Country = "Scotland" }
                );
        }

    }
}
