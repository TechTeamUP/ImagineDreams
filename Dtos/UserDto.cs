using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Dtos
{
    public class UserDto
    {  
        public long Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}