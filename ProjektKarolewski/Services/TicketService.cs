using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Exceptions;
using ProjektKarolewski.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjektKarolewski.Services
{
    public interface ITicketService
    {
        int Create(int deviceId, CreateTicketDto createTicketDto);
        TicketDto GetById(int deviceId, int ticketId);
        List<TicketDto> GetAll(int deviceId);
        void RemoveById(int deviceId, int ticketId);
        void Update(int deviceId, TicketDto ticketDto, int ticketId);
    }
    public class TicketService : ITicketService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public TicketService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(int deviceId, CreateTicketDto createTicketDto)
        {
            var device = GetDeviceById(deviceId);

            var ticket = _mapper.Map<Ticket>(createTicketDto);

            ticket.DeviceId = deviceId;
            ticket.TicketStatusId = createTicketDto.TicketStatusId;
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return ticket.Id;
        }

        public List<TicketDto> GetAll(int deviceId)
        {
            var device = GetDeviceById(deviceId);

            var ticket = _context.Tickets
                .Include(i => i.TicketStatus)
                .Include(i => i.Device)
                .Where(i => i.DeviceId == deviceId);
            

            var ticketDtos = _mapper.Map<List<TicketDto>>(ticket);
            return ticketDtos;
        }

        public TicketDto GetById(int deviceId, int ticketId)
        {
            var device = GetDeviceById(deviceId);

            var ticket = _context.Tickets
                .Include(i => i.TicketStatus)
                .Include(i => i.Device)
                .FirstOrDefault(i => i.Id == ticketId);
            if (ticket is null || ticket.DeviceId != deviceId)
            {
                throw new NotFoundException("Ticket not found");
            }

            var ticketDto = _mapper.Map<TicketDto>(ticket);
            return ticketDto;
        }

        public void RemoveById(int deviceId, int ticketId)
        {
            var device = GetDeviceById(deviceId);

            var ticket = _context.Tickets.FirstOrDefault(i => i.Id == ticketId);
            if (ticket is null || ticket.DeviceId != deviceId)
            {
                throw new NotFoundException("Ticket not found");
            }

            var ticketDto = _mapper.Map<TicketDto>(ticket);

            _context.Remove(ticket);
            _context.SaveChanges();

        }

        public void Update(int deviceId, TicketDto ticketDto, int ticketId)
        {
            var device = GetDeviceById(deviceId);
            var ticket = _context.Tickets
                .Include(i => i.TicketStatus)
                .Include(i => i.Device)
                .FirstOrDefault(i => i.Id == ticketId);
            if(ticket is null || ticket.DeviceId != deviceId)
            {
                throw new NotFoundException("Ticket not found");
            }

            ticket.TicketDate = ticketDto.TicketDate;
            ticket.TicketDescription = ticketDto.TicketDescription;
            ticket.Notifier = ticketDto.Notifier;
            ticket.TicketStatusId = ticketDto.TicketStatusId;

            _context.SaveChanges();

        }

        private Device GetDeviceById(int deviceId)
        {
            var device = _context
                .Devices
                .Include(d => d.Inspections)
                .FirstOrDefault(d => d.Id == deviceId);
            if (device is null)
                throw new NotFoundException("Device not found");

            return device;
        }
    }
}
