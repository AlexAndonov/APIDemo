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
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            var products = service.GetAll();

            return Ok(products); // This should return status code 200 with all the products.
        }


        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(int id)
        {
            var product = service.GetById(id);

            if (product == null)
            {
                return NotFound(); //This should return status code 404 Not Found
            }

            return Ok(product); //This should return status code 200 with the product
        }

        [HttpPost]
        public ActionResult<ProductDto> Create(CreateProductDto model)
        {
            var product = service.Create(model);

            return CreatedAtAction(nameof(GetById), new {Id = product.Id}, product);
        }
    }
}
