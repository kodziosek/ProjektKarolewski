using System.Collections.Generic;

namespace ProjektKarolewski.Entities
{
    public class TicketStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

    }
}
