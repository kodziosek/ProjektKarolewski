using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Service> Services { get; set; }
    }
}
