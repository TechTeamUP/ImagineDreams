namespace ImagineDreams.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Img { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}