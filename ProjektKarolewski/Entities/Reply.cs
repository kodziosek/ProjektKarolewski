using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Entities
{
    public class Reply
    {
        public int Id { get; set; }
        public DateTime ReplyDate { get; set; }
        public string ReplyDescription { get; set; }
        public string ReplyProtocol { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
