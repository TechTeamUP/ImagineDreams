using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ImagineDreams.Request;
using ImagineDreams.Services;

namespace ImagineDreams.Configuration
{
    public interface IToken
    {
        string GetToken(UserLoginRequest user);
    }

    public class Token : IToken
    {
        private readonly AppSettings _appSettings;
        private readonly IUserServices _userServices;

        public Token(IOptions<AppSettings> appSettings, IUserServices userServices)
        {
            _appSettings = appSettings.Value;
            _userServices = userServices;
        }

        public string GetToken(UserLoginRequest user)
        {
            var usuario = _userServices.getUserByEmail(user.Email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secrect);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email,user.Email)
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}