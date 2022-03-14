using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Models
{
    public class ReplyDto
    {
        public int Id { get; set; }
        public DateTime ReplyDate { get; set; }
        public string ReplyDescription { get; set; }
        public string ReplyProtocol { get; set; }

    }
}
