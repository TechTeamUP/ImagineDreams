using Microsoft.EntityFrameworkCore;
using ImagineDreams.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ImagineDreams.Repositories;
using ImagineDreams.Request;
using ImagineDreams.Response;
using ImagineDreams.Configuration;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ImagineDreams.Services
{
    public interface IUserServices
    {
        Task<UserEntity?> getUserByEmail(string email);
        Task<UserLoginResponse?> login(UserLoginRequest u);
        Task<UserCreateResponse> createUser(UserCreateRequest u);
        Task<UserEntity> getUserById(int id);
    }

    public class UserServices : IUserServices
    {
        private readonly DatabaseConentext _userDatabaseContext;
        private readonly AppSettings _appSettings;
        public UserServices(IOptions<AppSettings> appSettings, DatabaseConentext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
            _appSettings = appSettings.Value;
        }


        public string encrypt(string str)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(str);
            result = Convert.ToBase64String(encryted);
            return result;
        }


        private string GetToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secrect);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        //new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                        new Claim(ClaimTypes.Email,email)
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string decrypt(string str)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(str);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }


        public async Task<UserEntity?> getUserByEmail(string email)
        {
            var x = await _userDatabaseContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return x;
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


        public async Task<UserLoginResponse?> login(UserLoginRequest u)
        {
            var user = await getUserByEmail(u.Email);
            if (user == null)
            {
                return null;
            }

            var userC = await _userDatabaseContext.Users.FirstOrDefaultAsync(x => x.Email == u.Email.ToLower() && x.Password == encrypt(u.Password));
            if (userC == null)
            {
                return null;
            }
            return new UserLoginResponse()
            {
                Email = u.Email,
                Token = GetToken(u.Email)
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