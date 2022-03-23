using System.ComponentModel.DataAnnotations;

namespace ProjektKarolewski.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string LastName { get; set; }
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string Username { get; set; }
        [MinLength(6, ErrorMessage = "Pole musi zawierać minimum 6 znaków")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}
