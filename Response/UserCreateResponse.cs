namespace ImagineDreams.Response
{
    public class UserCreateResponse
    {
        public int Code { get; set; }
        public bool State { get; set; }
        public string Messagge { get; set; } = default!;
        public List<string>? Errors { get; set; }
    }
}