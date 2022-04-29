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

        [ForeignKey("State")]   
        public int StateId { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("Product")]
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

        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        public SalesModel ToModel()
        {
            return new SalesModel()
            {
                Quantity = Quantity,
                StateId = StateId,
                UserId = UserId,
                ProductId = ProductId
                
            };
        }
    }

    public class CreateSale
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Total { get; set; }

        [Required]
        public int UserIdBuyer { get; set; }

        [Required]
        public int ProductId { get; set; }

         public int StateId { get; set; }

    }
}