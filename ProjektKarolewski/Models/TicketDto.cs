using System;


namespace ProjektKarolewski.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public DateTime TicketDate { get; set; }
        public string TicketDescription { get; set; }
        public string Notifier { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int TicketStatusId { get; set; }
        public string TicketStatus { get; set; }
    }
}
