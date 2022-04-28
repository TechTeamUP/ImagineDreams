using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Models;
using ImagineDreams.Services;
using System.Text.Json;

using ImagineDreams.Request;
using Microsoft.AspNetCore.Authorization;

namespace ImagineDreams.Controllers
{   
    [ApiController]
    [Route("product/[controller]")]
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> createProduct(ProductCreateRequest product)
        {
            var response = await _productServices.createProduct(product);
            HttpContext.Session.SetString("CustomerSession", JsonSerializer.Serialize(response));
            return new ObjectResult(response);
        }


        [HttpGet("list")]
        public async Task<IActionResult> listProduct()
        {
            try
            {
                var response = await _productServices.listProduct();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("There are not products to display.");
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
            catch (Exception)
            {
                return BadRequest("Producto not found.");
            }
        }


        [HttpPut("update")]
        public async Task<IActionResult> updateProduct(ProductModel product)
        {
            try
            {
                var response = await _productServices.updateProduct(product);
                return Ok("Product update successfully.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> deleteProduct(int id)
        {
            try
            {
                var p = await _productServices.deleteProduct(id);
                return Ok("Product removed successfully.");
            }
            catch (Exception)
            {
                return BadRequest("Product not found.");
            }
        }
    }
}