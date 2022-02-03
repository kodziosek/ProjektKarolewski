using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class InspectionDto
    {
        public int Id { get; set; }
        public DateTime InspectionDate { get; set; }
        public int InspectionFrequency { get; set; }
        public bool Warranty { get; set; }
        public byte[] Scan { get; set; }
        public int InspectionTypeId { get; set; }
        public string InspectionType { get; set; }
        public int ServiceId { get; set; }
        public string Service { get; set; }


    }
}
