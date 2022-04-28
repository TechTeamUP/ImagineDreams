namespace ImagineDreams.Response
{
    public class UserLoginResponse
    {
        public int Code { get; set; }
        public bool Login { get; set; }
        public string Messagge { get; set; } = default!;
        public string Token { get; set; } = default!;
        public List<string>? Error { get; set; }
    }
}