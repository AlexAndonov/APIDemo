using APIDemo.Data;
using APIDemo.DTOs;
using APIDemo.Models;
using APIDemo.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APIDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext _context)
        {
                context = _context;
        }


        public ProductDto Create(CreateProductDto model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price
            };

            context.Add(product);
            context.SaveChanges();

            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public bool Delete(int id)
        {
            var product = context.Products.Find(id);

            if (product == null)
            {
                return false;
            }

            context.Remove(product);
            context.SaveChanges();

            return true;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
            });
        }

        public ProductDto? GetById(int id)
        {
            var product = context.Products.Find(id);

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

        public ProductDto? Patch(int id, PatchProductDto model)
        {
            var product = context.Products.Find(id);

            if (product == null)
            {
                return null;
            }

            if (model.Name != null)
            {
                product.Name = model.Name;
            }

            if (model.Price.HasValue)
            {
                product.Price = model.Price.Value;
            }

            context.SaveChanges();

            return new ProductDto()
            {

                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
        
        public ProductDto? Update(int id, CreateProductDto model)
        {
            var product = context.Products.Find(id);

            if (product == null)
            {
                return null;
            }

            product.Name = model.Name;
            product.Price = model.Price;

            context.SaveChanges();

            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
