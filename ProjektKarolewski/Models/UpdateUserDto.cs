namespace ProjektKarolewski.Models
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}
