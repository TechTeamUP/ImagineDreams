using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Dtos
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "The Fullname must be specified.")]
        public string Fullname { get; set; } = string.Empty;
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "It is not a correct email.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "The Password must be specified.")]
        public string Password { get; set; } = string.Empty;
    }
}