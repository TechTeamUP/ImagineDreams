using Microsoft.EntityFrameworkCore;
using ImagineDreams.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ImagineDreams.Repositories
{
    public class UserDatabaseContext : DbContext
    {
        public string SetSHA(string str)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(str);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public string GetSHA(string str)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(str);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : base(options)
        { }
        public DbSet<UserEntity> Users { get; set; }


        /* OBTENEMOS EL USUARIO VERIFICANDO QUE EL USER ID SEA EL MISMO QUE TENEMOS ALMACENADO */
        public async Task<UserEntity> getUser(long id)
        {
            var userP = await Users.FirstOrDefaultAsync(x => x.Id == id);
            return userP ?? throw new Exception("The provided user does not exist");
        }

        /* VERIFICAMOS QUE EL EMAIL Y EL CORREO SEAN CORRECTOS. */
        public async Task<UserEntity> login(string mail, string password)
        {
            UserEntity? user = await Users.FirstOrDefaultAsync(x => x.Email == mail.ToLower() && x.Password == SetSHA(password));
            return user ?? throw new Exception("The Email and/or password are not correct.");
        }

        /* CREAMOS EL USUARIO */
        public async Task<UserEntity> createUser(CreateUserDto userDto)
        {
            UserEntity entity = new UserEntity()
            {
                Fullname = userDto.Fullname,
                Email = userDto.Email.ToLower(),
                Password = SetSHA(userDto.Password)
            };

            EntityEntry<UserEntity> response = await Users.AddAsync(entity);
            await SaveChangesAsync();
            return await getUser(response.Entity.Id ?? throw new Exception("Could not save."));
        }
    }

    /* MAPEO DE LA RESPUESTA */
    public class UserEntity
    {
        public long? Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Password { get; set; }

        public UserDto ToDto()
        {
            return new UserDto()
            {
                Id = Id ?? throw new Exception("The ID must not be null."),
                Fullname = Fullname,
                Email = Email,
                Password = "************"
            };
        }
    }
}
