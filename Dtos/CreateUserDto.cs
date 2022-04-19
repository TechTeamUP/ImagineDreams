using System.ComponentModel.DataAnnotations;

namespace ImagineDreams.Dtos
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "The ID must be specified.")]
        public long Id { get; set; }
        [Required(ErrorMessage = "The Firstname must be specified.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Lastname must be specified.")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Birth { get; set; }
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "It is not a correct email.")]
        public string Email { get; set; }
        public string Type { get; set; }
    }
}
// 
// {
//   "id": 1120380115,
//   "firstName": "Willintong",
//   "lastName": "Ramirez Rodriguez",
//   "address": "Carrera 4 #5-66",
//   "phone": "3222292310",
//   "birth": "2022-04-19T00:51:02.807Z",
//   "email": "willintong@hotmail.com",
//   "type": "Customer"

// }