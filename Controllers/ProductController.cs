using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Repositories;
using ImagineDreams.Models;

namespace ImagineDreams.Controllers
{   
    [ApiController]
    [Route("service/product")]
    public class ProductController: Controller
    {
        private readonly UserDatabaseContext _ProductDatabaseContext;
        public ProductController(UserDatabaseContext productDatabaseContext)
        {
            _ProductDatabaseContext = productDatabaseContext;
        }

        // [HttpPost("create")]
        // public async Task<IActionResult> createProduct(Product product)
        // {
        //     try
        //     {
        //         ProductEntity response = await _ProductDatabaseContext.createProduct(product);
        //         return new ObjectResult(response);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
    }
}