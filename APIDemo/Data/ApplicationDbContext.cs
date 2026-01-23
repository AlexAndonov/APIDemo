using APIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasData
                (
                    new Product() { Id = 1, Name = "Pizza", Price = 21.99M },
                    new Product() { Id = 2, Name = "Noodle Soup", Price = 12.99M },
                    new Product() { Id = 3, Name = "Grilled Salmon", Price = 24.99M },
                    new Product() { Id = 4, Name = "Pasta Carbonara", Price = 16.99M },
                    new Product() { Id = 5, Name = "Cake", Price = 9.99M }
                );
        }


        public DbSet<Product> Products { get; set; }
    }
}
 