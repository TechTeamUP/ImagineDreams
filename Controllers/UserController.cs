using Microsoft.AspNetCore.Mvc;
using ImagineDreams.Dtos;
using ImagineDreams.Repositories;

namespace ImagineDreams.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        //EL READONLY ES LA CONEXIÓN A LA BD, SE PUEDE MEJORAR (PENDIENTE A OPTIMIZACIÓN).
        private readonly UserDatabaseContext _userDatabaseContext;
        public UserController(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        //ENDPOINT PARA LA CREACION DE UN USUARIO.
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> createUser(CreateUserDto user)
        {
            UserEntity result = await _userDatabaseContext.createUser(user);
            return new CreatedResult($"https://localhost:7200/api/customer/{result.Id}", null);
        }

        //ENDPOINT PARA LISTAR USUARIOS
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> getUsers()
        {
            var result = _userDatabaseContext.Users.Select(c => c.ToDto()).ToList();
            return new ObjectResult(result);
        }

    }
}
