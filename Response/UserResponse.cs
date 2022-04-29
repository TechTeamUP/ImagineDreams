namespace ImagineDreams.Response
{
    public class UserResponse
    {
        public int Code { get; set; }
        public string Message { get; set; } = default!;
        public UserLoginResponse? Data { get; set; }
    }
}
