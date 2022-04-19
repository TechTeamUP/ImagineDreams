using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Dtos
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "The ID must be specified.")]
        public long Id { get; set; }
        [Required(ErrorMessage = "The Firstname must be specified.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Lastname must be specified.")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Birth { get; set; }
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "It is not a correct email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password must be specified.")]
        public string Password { get; set; }
    }
}