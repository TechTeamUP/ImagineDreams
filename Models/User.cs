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

        public DateTime Created_Date { get; set; } = DateTime.Now;
    }

    public class UserEntity
    {
        [Key,]
        public int? Id { get; set; }

        [StringLength(60)]
        public string Fullname { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        public DateTime Created_Date { get; set; } = DateTime.Now;

        public ICollection<ProductEntity> Product { get; set; } = default!;
        
        public ICollection<SalesEntity> Sale { get; set; } = default!;

        public UserEntity ToModel()
        {
            return new UserEntity()
            {
                Fullname = Fullname,
                Email = Email,
                Password = "************"
            };
        }
    }
}