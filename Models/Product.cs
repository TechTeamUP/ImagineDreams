using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name must be specified.")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Img { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Price must be specified.")]
        public float Price { get; set; }

        [Required(ErrorMessage = "The Stock must be specified.")]
        public int Stock { get; set; }

        public DateTime Created_Date { get; set; } = DateTime.Now;

        public DateTime Update_Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "The UserID must be specified.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The Category must be specified.")]
        public int CategoryId { get; set; }

    }
}