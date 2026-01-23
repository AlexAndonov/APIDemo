using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace APIDemo.Models.SeedDb
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
              .HasData
              (
                  new Product() { Id = 1, Name = "Pizza", Price = 21.99M },
                  new Product() { Id = 2, Name = "Noodle Soup", Price = 12.99M },
                  new Product() { Id = 3, Name = "Grilled Salmon", Price = 24.99M },
                  new Product() { Id = 4, Name = "Pasta Carbonara", Price = 16.99M },
                  new Product() { Id = 5, Name = "Cake", Price = 9.99M }
              );
        }
    }
}
