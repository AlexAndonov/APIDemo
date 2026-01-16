using APIDemo.DTOs;
using APIDemo.Models;
using APIDemo.Services.Interfaces;

namespace APIDemo.Services
{
    public class ProductService : IProductService
    {
        private static readonly List<Product> products =
            [
                new Product(){ Id = 1, Name = "Pizza", Price = 21.99M},
                new Product(){ Id = 2, Name = "Noodle Soup", Price = 13.99M},
                new Product(){ Id = 3, Name = "Grilled Salmon", Price = 25.99M},
                new Product(){ Id = 4, Name = "Grilled Chicken", Price = 14.99M},
                new Product(){ Id = 5, Name = "Pasta Carbonara", Price = 19.99M},
            ];
        public ProductDto Create(CreateProductDto model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price
            };

            products.Add(product);

            return new ProductDto()
            {
                Name = product.Name,
                Price = product.Price
            };
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
            });
        }

        public ProductDto? GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
