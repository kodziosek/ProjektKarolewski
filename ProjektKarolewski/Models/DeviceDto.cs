using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameInPassport { get; set; }
        public string AcquisitionDate { get; set; }
        public string ProductionDate { get; set; }
        public string PassportNumber { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Comments { get; set; }
        public string Ward { get; set; }
        public string Producer { get; set; }
    }
}
