using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Models;
using ImagineDreams.Repositories;
using ImagineDreams.Mapping;
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("log_in")]
        public async Task<IActionResult> login(string mail, string password)
        {
            try
            {
                UserEntity result = await _userServices.login(mail, password);
                return new OkObjectResult(result.ToDto());
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
                return new ObjectResult(result.ToDto());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
