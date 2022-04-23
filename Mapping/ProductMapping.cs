using ImagineDreams.Models;
namespace ImagineDreams.Mapping
{
    public class ProductMapping { }

    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Stock { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
        public DateTime Update_Date { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }

        public Product ToModel()
        {
            return new Product()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price,
                Stock = Stock,
                CategoryId = CategoryId
            };
        }
    }
}