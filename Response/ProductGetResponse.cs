namespace ImagineDreams.Response
{
    public class ProductGetResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Img { get; set; } = string.Empty;
        public float Price { get; set; } = default!;
        public int Stock { get; set; } = default!;
        public string user { get; set; } = default!;
        public int CategoryId { get; set; }
    }
}