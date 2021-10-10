using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Entities
{
    public class Fault
    {
        public int Id { get; set; }
        public DateTime FaultDate { get; set; }
        public string FaultDescription { get; set; }

        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }
        public int RepairId { get; set; }
        public virtual Repair Repair { get; set; }
    }
}
