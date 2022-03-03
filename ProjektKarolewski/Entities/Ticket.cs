using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime TicketDate { get; set; }
        public string TicketDescription { get; set; }
        public string Notifier { get; set; }

        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }
        public int ReplyId { get; set; }
        public virtual Reply Reply { get; set; }
        public int TicketStatusId { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
    }
}
