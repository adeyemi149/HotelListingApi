using System.ComponentModel.DataAnnotations;

namespace HotelCountry_Redo.Core.DTOs
{
    public class UserDTO : LoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }
    }

    public class LoginDTO
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your passwod is limited to {2} to {1}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
