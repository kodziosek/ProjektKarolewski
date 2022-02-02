using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Wymagany login!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Wymagane hasło!")]
        public string Password { get; set; }
    }
}
