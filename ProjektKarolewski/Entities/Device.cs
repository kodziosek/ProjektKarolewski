using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ProjektKarolewski.Entities
{
    public class Device
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

        public int WardId { get; set; }
        public virtual Ward Ward { get; set; }
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
        public virtual List<Inspection> Inspections { get; set; }
        
    }
}
