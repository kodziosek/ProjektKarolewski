﻿namespace ProjektKarolewski.Models
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}
