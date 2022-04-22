using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Dtos;
using ImagineDreams.Repositories;

namespace ImagineDreams.Controllers
{
    [ApiController]
    [Route("services/user")]
    public class UserController : Controller
    {
        
        private readonly UserDatabaseContext _userDatabaseContext;
        public UserController(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }


        [HttpPost()]
        public async Task<IActionResult> createUser(CreateUserDto user)
        {
            try
            {
                UserEntity result = await _userDatabaseContext.createUser(user);
                return new CreatedResult($"https://localhost:7200/api/customer/{result.Id}", null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("list")]
        public async Task<IActionResult> getUsers()
        {
            try
            {
                var result = _userDatabaseContext.Users.Select(c => c.ToDto()).ToList();
                return new ObjectResult(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get")]
        public async Task<IActionResult> getUserById(long id)
        {
            try
            {
                UserEntity result = await _userDatabaseContext.getUser(id);
                return new ObjectResult(result.ToDto());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
