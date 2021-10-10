using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class CreateDeviceDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string NameInPassport { get; set; }
        [Required]
        [MaxLength(10)]
        public string AcquisitionDate { get; set; }
        [Required]
        [MaxLength(10)]
        public string ProductionDate { get; set; }
        [Required]
        [MaxLength(10)]
        public string PassportNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Comments { get; set; }

        public int WardId { get; set; }

        public int ProducerId { get; set; }
    }
}
