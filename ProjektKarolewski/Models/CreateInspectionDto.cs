using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class CreateInspectionDto
    {
        [Required]
        public DateTime InspectionDate { get; set; }
        [Required]
        public int InspectionFrequency { get; set; }
        public bool Warranty { get; set; }
        public byte[] Scan { get; set; }

        public int InspectionTypeId { get; set; }
        public int DeviceId { get; set; }
        public int ServiceId { get; set; }
    }
}
