using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Repositories;
using ImagineDreams.Models;
using ImagineDreams.Services;
using ImagineDreams.Mapping;

namespace ImagineDreams.Controllers
{   
    [ApiController]
    [Route("service/product")]
    public class ProductController: Controller
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> createProduct(Product product)
        {
            try
            {
                ProductEntity response = await _productServices.createProduct(product);
                return new ObjectResult(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}