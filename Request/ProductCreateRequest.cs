using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Request
{
    public class ProductCreateRequest
    {
        public int Id { get; set; }

        [StringLength(60), Required]
        public string Name { get; set; } = default!;

        [StringLength(255), Required]
        public string? Description { get; set; }

        [Required]
        public string Img { get; set; } = default!;

        [Required]
        public float Price { get; set; } = default!;

        [Required]
        public int Stock { get; set; } = default!;

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}