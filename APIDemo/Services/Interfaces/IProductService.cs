using APIDemo.DTOs;

namespace APIDemo.Services.Interfaces
{
	public interface IProductService
	{
		IEnumerable<ProductDto> GetAll();
		ProductDto? GetById(int id);
		ProductDto Create(CreateProductDto model);
		ProductDto? Update(int id,CreateProductDto model);
		bool Delete(int id);
	}
}
