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

        
        [HttpGet("list")]
        public async Task<IActionResult> listProduct()
        {
            try
            {
                var response = await _productServices.listProduct();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getProductByName(int id)
        {
            try
            {
                var response = await _productServices.getProduct(id);
                return Ok(response);
            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("update")]
        public async Task<IActionResult> updateProduct(Product product)
        {
            try
            {
                var response = await _productServices.updateProduct(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}