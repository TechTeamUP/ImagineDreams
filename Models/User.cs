using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Models
{
    public class UsersModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60)]
        public string Fullname { get; set; } = default!;

        [StringLength(100)]
        public string Email { get; set; } = default!;

        [StringLength(60)]
        public string Password { get; set; } = default!;

        public DateTime Created_Date { get; set; }
    }

    public class UserEntity
    {
        [Key]
        public int? Id { get; set; }

        [StringLength(60)]
        public string Fullname { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(60)]
        public string Password { get; set; } = string.Empty;

        public ICollection<ProductEntity> Product { get; set; } = default!;

        public UsersModel ToModel()
        {
            return new UsersModel()
            {
                Fullname = Fullname,
                Email = Email,
                Password = "************"
            };
        }
    }

    public class CreateUser
    {
        [Required(ErrorMessage = "The Firstname must be specified.")]
        public string Fullname { get; set; } = default!;

        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "It is not a correct email.")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "The Password must be specified.")]
        public string Password { get; set; } = default!;
    }
}