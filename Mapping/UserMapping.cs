using ImagineDreams.Models;

namespace ImagineDreams.Mapping
{
    public class UserMapping { }

    public class UserEntity
    {
        public long? Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public User ToModel()
        {
            return new User()
            {
                Id = Id ?? throw new Exception("The ID must not be null."),
                Fullname = Fullname,
                Email = Email,
                Password = "************"
            };
        }
    }
}