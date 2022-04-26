using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagineDreams.Models
{
    public class SalesModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Total { get; set; }

        public DateTime Created_date { get; set; }

        public string state {get; set; } = default!;

        [ForeignKey("UserIdBuyer")]
        public int UserIdBuyer { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
    }

    public class SalesEntity
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Total { get; set; }

        public DateTime Created_date { get; set; }

        public string state {get; set; } = default!;

        [ForeignKey("UserIdBuyer")]
        public int UserIdBuyer { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
    }

    public class CreateSale
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Total { get; set; }

        public DateTime Created_date { get; set; }

        [Required]
        public int UserIdBuyer { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}