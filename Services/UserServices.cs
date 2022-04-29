using Microsoft.EntityFrameworkCore;
using ImagineDreams.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ImagineDreams.Repositories;
using ImagineDreams.Request;
using ImagineDreams.Response;

namespace ImagineDreams.Services
{
    public interface IUserServices
    {
        Task<UserEntity> getUserByEmail(string email);
        Task<UserLoginResponse> login(UserLoginRequest u);
        Task<UserCreateResponse> createUser(UserCreateRequest u);
        Task<UserEntity> getUserById(int id);
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


        public async Task<UserEntity> getUserByEmail(string email)
        {
            try
            {
                 UserEntity? x =  await _userDatabaseContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
                return x;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<UserEntity> getUserById(int id)
        {
            UserEntity? userP = await _userDatabaseContext.Users.Include(x => x.Id).FirstOrDefaultAsync(x => x.Id == id);
            if (userP == null)
            {
                return userP ?? throw new Exception("The provided user does not exist.");
            }
            return new UserEntity() { Fullname = userP.Fullname };
        }


        public async Task<UserLoginResponse> login(UserLoginRequest u)
        {
            var user = getUserByEmail(u.Email);
            if (user == null)
            {
                return new UserLoginResponse()
                {
                    Code = 404,
                    Login = false,
                    Messagge = "The provided Email does not exist!",
                    Error = new List<string>()
                    {
                        "Not found"
                    }
                };
            }

            var userC = await _userDatabaseContext.Users.FirstOrDefaultAsync(x => x.Email == u.Email.ToLower() && x.Password == encrypt(u.Password));
            if (userC == null)
            {
                return new UserLoginResponse()
                {
                    Code = 400,
                    Login = false,
                    Messagge = "The Email and/or password are not correct!",
                    Error = new List<string>()
                    {
                        "Bad request"
                    }
                };
            }
            return new UserLoginResponse()
            {
                Code = 200,
                Login = true,
                Messagge = "You have successfully logged in!",
                Error = new List<string>()
                {
                    "Ok"
                }
            };
        }


        public async Task<UserCreateResponse> createUser(UserCreateRequest u)
        {
            var user = await getUserByEmail(u.Email);
            if (user != null)
            {
                return new UserCreateResponse()
                {
                    Code = 400,
                    State = false,
                    Errors = new List<string>()
                    {
                        "Email is already in use!"
                    }
                };
            }
            UserEntity entity = new UserEntity()
            {
                Fullname = u.Fullname,
                Email = u.Email.ToLower(),
                Password = encrypt(u.Password)
            };

            EntityEntry<UserEntity> response = await _userDatabaseContext.Users.AddAsync(entity);
            await _userDatabaseContext.SaveChangesAsync();
            return new UserCreateResponse()
            {
                Code = 201,
                State = true,
                Messagge = "User created successfully",
                Errors = new List<string>()
            };
        }
    }
}