using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Models
{
    public class CreateUser
    {
        [Required(ErrorMessage = "The Firstname must be specified.")]
        public string? Fullname { get; set; }
        
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "It is not a correct email.")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "The Password must be specified.")]
        public string? Password { get; set; }
    }
}