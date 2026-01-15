using APIDemo.DTOs;
using APIDemo.Models;
using APIDemo.Services.Interfaces;

namespace APIDemo.Services
{
	public class ProductService : IProductService
	{
		private static readonly List<Product> products = [];
		public ProductDTO Create(CreateProductDTO model)
		{
			var product = new Product()
			{
				Id = Guid.NewGuid(),
				Name = model.Name,
				Description = model.Description,
				Price = model.Price
			};

			products.Add(product);

			return new ProductDTO()
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price
			};
		}

		public IEnumerable<ProductDTO> GetAll()
		{
			return products.Select(p => new ProductDTO
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
			});
		}

		public ProductDTO? GetById(Guid id)
		{
			return products.Select(p => new ProductDTO
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
			})
			.FirstOrDefault();
		}
	}
}
