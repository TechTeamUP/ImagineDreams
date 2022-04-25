using Microsoft.EntityFrameworkCore;
using ImagineDreams.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ImagineDreams.Repositories;

namespace ImagineDreams.Services
{
    public interface IUserServices
    {
        Task<UserEntity> getUser(string email);
        Task<UserEntity> login(string email, string password);
        Task<UserEntity> createUser(CreateUser user);
    }

    public class UserServices : IUserServices
    {
        private readonly DatabaseConentext _userDatabaseContext;
        public UserServices(DatabaseConentext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }


        public string encrypt(string str)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(str);
            result = Convert.ToBase64String(encryted);
            return result;
        }


        public string decrypt(string str)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(str);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }


        public async Task<UserEntity> getUser(string email)
        {
            var userP = await _userDatabaseContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return userP ?? throw new Exception("The provided user does not exist.");
        }


        public async Task<UserEntity> login(string email, string password)
        {
            var user = await _userDatabaseContext.Users.FirstOrDefaultAsync(x => x.Email == email.ToLower() && x.Password == encrypt(password));
            return user ?? throw new Exception("The Email and/or password are not correct.");
        }


        public async Task<UserEntity> createUser(CreateUser user)
        {
            UserEntity entity = new UserEntity()
            {
                Fullname = user.Fullname,
                Email = user.Email.ToLower(),
                Password = encrypt(user.Password)
            };

            EntityEntry<UserEntity> response = await _userDatabaseContext.Users.AddAsync(entity);
            await _userDatabaseContext.SaveChangesAsync();
            return await getUser(response.Entity.Email);
        }
    }
}