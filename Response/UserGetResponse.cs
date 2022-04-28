namespace ImagineDreams.Response
{
    public class UserGetResponse
    {
        public int? Id { get; set; }
        public string Fullname { get; set; } = default!;
        public string  Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}