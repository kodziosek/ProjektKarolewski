using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class ProducerDto
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string Name { get; set; }

    }
}
