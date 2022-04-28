using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagineDreams.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60), Required]
        public string Name { get; set; } = default!;

        [StringLength(255), Required]
        public string? Description { get; set; }

        [Required]
        public string Img { get; set; } = string.Empty;

        [Required]
        public float Price { get; set; } = default!;

        [Required]
        public int Stock { get; set; } = default!;

        public int UserId { get; set; }

        public int CategoryId { get; set; }
    }

    public class ProductEntity
    {
        [Key]
        public int? Id { get; set; }

        [StringLength(60), Required(ErrorMessage = "The Name must be specified.")]
        public string Name { get; set; } = default!;

        [StringLength(255), Required]
        public string? Description { get; set; }

        [Required]
        public string Img { get; set; } = string.Empty;

        [Required]
        public float Price { get; set; } = default!;

        [Required]
        public int Stock { get; set; } = default!;

        public DateTime Created_Date { get; set; } = DateTime.Now;

        public DateTime Update_Date { get; set; } = DateTime.Now;

        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public ICollection<SalesEntity> Sale { get; set; } = default!;

    }
}