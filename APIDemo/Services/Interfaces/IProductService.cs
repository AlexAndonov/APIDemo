using APIDemo.DTOs;

namespace APIDemo.Services.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<ProductResponse>> GetAllAsync();
		Task<ProductResponse?> GetByIdAsync(int id);
		Task<ProductResponse> CreateAsync(ProductCreateRequest model);
		Task<ProductResponse?> UpdateAsync(int id,ProductCreateRequest model);
		Task<ProductResponse?> PatchAsync(int id, ProductPatchRequest model);
		Task<bool> DeleteAsync(int id);
	}
}
