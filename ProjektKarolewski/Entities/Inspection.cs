using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Entities
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateTime InspectionDate { get; set; }
        public int InspectionFrequency { get; set; }
        public bool Warranty { get; set; }
        public byte[] Scan { get; set; }

        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }
        public int InspectionTypeId { get; set; }
        public virtual InspectionType InspectionType { get; set; }
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

    }
}
