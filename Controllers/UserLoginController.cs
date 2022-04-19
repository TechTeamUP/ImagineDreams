using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Dtos;
using ImagineDreams.Repositories;

namespace ImagineDreams.Controllers
{
    [ApiController]
    [Route("service/login")]
    public class UserLoginController: Controller
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        public UserLoginController(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> login(string mail, string password)
        {
            UserEntity result = await _userDatabaseContext.login(mail, _userDatabaseContext.getSHA(password));
            if(result == null)
            {
                return Unauthorized(result);
            }
            return new ObjectResult(result);
        }
    }
}