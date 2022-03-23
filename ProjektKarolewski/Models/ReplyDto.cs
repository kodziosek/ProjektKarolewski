using CustomDataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class ReplyDto
    {
        public int Id { get; set; }
        [CurrentDate(ErrorMessage = "Data musi być poźniejsza niż dzisiejsza")]
        public DateTime ReplyDate { get; set; }
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string ReplyDescription { get; set; }
        public string ReplyProtocol { get; set; }

    }
}
