namespace ImagineDreams.Response
{
    public class ProductCreateResponse
    {
        public int Code { get; set; }
        public bool Create { get; set; }
        public string? Message { get; set; }
        public List<string>? Error { get; set; }
    }
}