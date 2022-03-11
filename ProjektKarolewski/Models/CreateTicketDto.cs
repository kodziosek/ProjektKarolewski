using System;


namespace ProjektKarolewski.Models
{
    public class CreateTicketDto
    {
        public DateTime TicketDate { get; set; }
        public string TicketDescription { get; set; }
        public string Notifier { get; set; }

        public int DeviceId { get; set; }
        public int TicketStatusId { get; set; }

    }
}
