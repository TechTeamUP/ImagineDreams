using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Models
{
    public class CategoryEntity
    {   
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        
        public ICollection<ProductEntity> Product { get; set; } = default!;
    }
}