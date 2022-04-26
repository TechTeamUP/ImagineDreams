using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Models;
using ImagineDreams.Services;


namespace ImagineDreams.Controllers
{   
    [ApiController]
    [Route("service/sales")]
    public class SalesController: Controller
    {
        private readonly ISalesServices _SalesServices;
        public SalesController(ISalesServices SalesServices)
        {
            _SalesServices = SalesServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> createSales(CreateSale sales)
        {
            try
            {
                SalesEntity response = await _SalesServices.createSales(sales);
                return new ObjectResult("Sales created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}