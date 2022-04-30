using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Models;
using ImagineDreams.Services;
using ImagineDreams.Request;
using Microsoft.AspNetCore.Authorization;
using ImagineDreams.Response;

namespace ImagineDreams.Controllers
{
    [ApiController]
    [Route("service/[controller]")]

    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> createUser([FromBody] UserCreateRequest user)
        {
            var result = await _userServices.createUser(user);
            if (result.Code == 400)
            {
                return BadRequest(result);
            }
            return new ObjectResult(result);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] UserLoginRequest u)
        {
            var result = await _userServices.login(u);
            UserResponse Response =  new UserResponse();
            if(result == null)
            {
                Response.Code = 400;
                Response.Message = "The Email and/or Password are not correct!";
                return BadRequest(Response);
            }
            Response.Code = 200;
            Response.Data = result;
            Response.Message = "User logged in successfully";

            return new ObjectResult(Response);
          
        }

        [HttpGet]
        [Route("get")]
        [Authorize]
        public async Task<IActionResult> getUserByEmail(string email)
        {
            var result = await _userServices.getUserByEmail(email);
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> test(int id)
        {
            UserEntity result = await _userServices.getUserById(id);
            return new ObjectResult(result);
        }
    }
}
