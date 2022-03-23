using CustomDataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjektKarolewski.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        [CurrentDate(ErrorMessage = "Data musi być poźniejsza niż dzisiejsza")]
        public DateTime TicketDate { get; set; }
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string TicketDescription { get; set; }
        public string Notifier { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int TicketStatusId { get; set; }
        public string TicketStatus { get; set; }
    }
}
