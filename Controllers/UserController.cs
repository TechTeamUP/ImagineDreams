using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Models;
using ImagineDreams.Services;

namespace ImagineDreams.Controllers
{
    [ApiController]
    [Route("service/user")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }


        [HttpPost("sign_up")]
        public async Task<IActionResult> createUser(CreateUser user)
        {
            try
            {
                UserEntity result = await _userServices.createUser(user);
                return new CreatedResult($"https://localhost:7200/api/customer/{result.Email}", null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("log_in")]
        public async Task<IActionResult> login(string mail, string password)
        {
            try
            {
                UserEntity result = await _userServices.login(mail, password);
                return new OkObjectResult(result.ToModel());
            }
            catch (Exception ex)
            {

                return Unauthorized(ex.Message);
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> getUserByEmail(string email)
        {
            try
            {
                UserEntity result = await _userServices.getUser(email);
                return new ObjectResult(result.ToModel());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
