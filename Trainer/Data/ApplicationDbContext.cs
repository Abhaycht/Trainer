using Microsoft.EntityFrameworkCore;
using Trainer.Models;

namespace Trainer.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Tamer> Tamers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tamer>().HasData(
                new Tamer { Id = 1, Name = "Marcus", Country = "India" },
                new Tamer { Id = 2, Name = "Thomas", Country = "England" },
                new Tamer { Id = 3, Name = "Lily", Country = "Scotland" }
                );
        }

    }
}
