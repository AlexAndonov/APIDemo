using APIDemo.DTOs;
using APIDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAll()
        {
            var products = await service.GetAllAsync();

            return Ok(products); // This should return status code 200 with all the products.
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResponse>> GetById(int id)
        {
            var product = await service.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound(); //This should return status code 404 Not Found
            }

            return Ok(product); //This should return status code 200 with the product
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> Create(ProductCreateRequest model)
        {
            var product = await service.CreateAsync(model);

            return CreatedAtAction(nameof(GetById), new {Id = product.Id}, product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductResponse>> Update(int id, ProductCreateRequest model)
        {
            var product = await service.UpdateAsync(id, model);

            if(product == null)
            {
                return NotFound(); //This returns 404 Not Found if the product doesn't exist or the ID is wrong
            }

            return Ok(product); //This returs status code 200 with the update product!
        }

        [HttpPatch]
        public async Task<ActionResult<ProductResponse>> Patch(int id, ProductPatchRequest model)
        {
            var product = await service.PatchAsync(id, model);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await service.DeleteAsync(id);

            if (result == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
