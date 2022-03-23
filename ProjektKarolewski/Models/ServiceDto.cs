using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class ServiceDto
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string ServiceName { get; set; }
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string Street { get; set; }
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string City { get; set; }
        [RegularExpression(@"\d{2}-\d{3}")]
        [MinLength(5, ErrorMessage = "Pole musi mieć format kodu pocztowego")]
        public string PostalCode { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public int ContractId { get; set; }
        public string Contract { get; set; }
    }
}
