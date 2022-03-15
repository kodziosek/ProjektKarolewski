using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetTicketByDevice(int deviceId);
        Task<IEnumerable<TicketDto>> GetTicketById(int deviceId, int ticketId);
        Task<TicketDto> AddTicket(TicketDto ticket, int deviceId);
        Task DeleteTicket(int ticketId, int deviceId);
        Task<TicketDto> UpdateTicket(TicketDto ticket, int deviceId, int ticketId);


    }
}
