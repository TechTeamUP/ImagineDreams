using Microsoft.EntityFrameworkCore;
using ImagineDreams.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ImagineDreams.Repositories

{
    public class UserDatabaseContext : DbContext
    {
        public UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : base(options)
        { }
        public DbSet<UserEntity> Users { get; set; }

        public async Task<UserEntity> getUser(long id)
        {
            return await Users.FirstOrDefaultAsync(x => x.Id == id);
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
                Type  = userDto.Type,
                Email = userDto.Email
                
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
        public string Type { get; set; }

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
                Type = Type 

            };
        }
    }
}