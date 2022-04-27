using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Request
{
    public class UserCreateRequest
    {
        [Required(ErrorMessage = "The Firstname must be specified.")]
        public string Fullname { get; set; } = default!;

        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "It is not a correct email.")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "The Password must be specified.")]
        public string Password { get; set; } = default!;
    }
}