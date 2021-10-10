using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Entities
{
    public class InspectionType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Inspection> Inspections { get; set; }
        
    }
}
