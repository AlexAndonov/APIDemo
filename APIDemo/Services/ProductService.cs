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


        public async Task<ProductResponse> CreateAsync(ProductCreateRequest model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price
            };

            context.Add(product);
            await context.SaveChangesAsync();

            return new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            context.Remove(product);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllAsync()
        {
            return context.Products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
            });
        }

        public async Task<ProductResponse?> GetByIdAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task<ProductResponse?> PatchAsync(int id, ProductPatchRequest model)
        {
            var product = await context.Products.FindAsync(id);

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

            await context.SaveChangesAsync();

            return new ProductResponse()
            {

                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
        
        public async Task<ProductResponse?> UpdateAsync(int id, ProductCreateRequest model)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            product.Name = model.Name;
            product.Price = model.Price;

            await context.SaveChangesAsync();

            return new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
