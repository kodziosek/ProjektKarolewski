using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class UpdateDeviceDto
    {

        public string Name { get; set; }
        public string NameInPassport { get; set; }
        public string AcquisitionDate { get; set; }
        public string ProductionDate { get; set; }
        public string PassportNumber { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Comments { get; set; }

        public int WardId { get; set; }

        public int ProducerId { get; set; }
    }
}
