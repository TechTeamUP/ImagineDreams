namespace ImagineDreams.Models
{
    public class User
    {
        public long Id { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime Created_Date { get; set; }
    }
}