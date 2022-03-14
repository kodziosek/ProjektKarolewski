using AutoMapper;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Services
{
    public interface ITicketStatusService
    {
        IEnumerable<TicketStatusDto> GetAll();
    }
    public class TicketStatusService : ITicketStatusService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public TicketStatusService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<TicketStatusDto> GetAll()
        {
            var ticketStatuses = _context
                .TicketStatuses
                .ToList();

            var ticketStatusDtos = _mapper.Map<List<TicketStatusDto>>(ticketStatuses);

            return ticketStatusDtos;
        }
    }
}
