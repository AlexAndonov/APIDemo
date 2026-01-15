using APIDemo.DTOs;

namespace APIDemo.Services.Interfaces
{
	public interface IProductService
	{
		IEnumerable<ProductDTO> GetAll();
		ProductDTO? GetById(Guid id);
		ProductDTO Create(CreateProductDTO model);
	}
}
