using System.ComponentModel.DataAnnotations;

namespace ProjektKarolewski.Models
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
    }
}