using Microsoft.EntityFrameworkCore;
using ImagineDreams.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace ImagineDreams.Repositories
{
    public class UserDatabaseContext : DbContext
    {
        public string getSHA(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte [] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : base(options)
        { }
        public DbSet<UserEntity> Users { get; set; }

        public async Task<UserEntity> getUser(long id)
        {
            return await Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserEntity> searchEmail(string mail)
        {
            return await Users.FirstOrDefaultAsync(x => x.Email == mail);
        }

        public async Task<UserEntity> login(string mail, string password)
        {
            UserEntity user = await Users.FirstOrDefaultAsync(x => x.Email == mail);
            if (user != null)
            {
                user = await Users.FirstOrDefaultAsync(x => x.Password == password);
                if (user != null)
                {
                    return user;
                }
            }
            return user;
        }

        public async Task<UserEntity> createUser(CreateUserDto userDto)
        {
            UserEntity entity = new UserEntity()
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Address = userDto.Address,
                Phone = userDto.Phone,
                Birth = userDto.Birth,
                Email = userDto.Email,
                Password = getSHA(userDto.Password)

            };

            EntityEntry<UserEntity> response = await Users.AddAsync(entity);
            await SaveChangesAsync();
            return await getUser(response.Entity.Id);
        }
    }


    public class UserEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDto ToDto()
        {
            return new UserDto()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Birth = Birth,
                Phone = Phone,
                Email = Email,
                Address = Address,
            };
        }
    }
}