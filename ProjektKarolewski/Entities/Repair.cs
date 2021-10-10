using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Entities
{
    public class Repair
    {
        public int Id { get; set; }
        public DateTime RepairDate { get; set; }
        public string RepairDescription { get; set; }
        public byte[] RepairProtocol { get; set; }

        public virtual Fault Fault { get; set; }
    }
}
