using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Exceptions;
using ProjektKarolewski.Models;

namespace ProjektKarolewski.Services
{
    public interface IReplyService
    {
        int Create(int ticketId, CreateReplyDto dto);
        ReplyDto GetById(int ticketId, int replyId);
        List<ReplyDto> GetAll(int ticketId);
        void RemoveById(int ticketId, int replyId);
        void Update(int ticketId, ReplyDto dto, int replyId);
    }
    public class ReplyService : IReplyService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public ReplyService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int ticketId, CreateReplyDto dto)
        {
            var ticket = GetTicketById(ticketId);

            var reply = _mapper.Map<Reply>(dto);

            reply.TicketId = ticketId;
            _context.Replies.Add(reply);
            _context.SaveChanges();

            return reply.Id;
        }

        public List<ReplyDto> GetAll(int ticketId)
        {
            var ticket = GetTicketById(ticketId);

            var replies = _context.Replies
                .Where(i => i.TicketId == ticketId);

            var replyDtos = _mapper.Map<List<ReplyDto>>(replies);

            return replyDtos;
        }

        public ReplyDto GetById(int ticketId, int replyId)
        {
            var ticket = GetTicketById(ticketId);

            var reply = _context.Replies
                .FirstOrDefault(i => i.Id == replyId);
            if(reply is null || reply.TicketId != ticketId)
            {
                throw new NotFoundException("Reply not found");
            }

            var replyDto = _mapper.Map<ReplyDto>(reply);
            return replyDto;
        }

        public void RemoveById(int ticketId, int replyId)
        {
            var ticket = GetTicketById(ticketId);

            var reply = _context.Replies
                .FirstOrDefault(i => i.Id == replyId);
            if (reply is null || reply.TicketId != ticketId)
            {
                throw new NotFoundException("Reply not found");
            }

            var replyDto = _mapper.Map<ReplyDto>(reply);
            _context.Remove(reply);
            _context.SaveChanges();
        }

        public void Update(int ticketId, ReplyDto dto, int replyId)
        {
            var ticket = GetTicketById(ticketId);
            var reply = _context.Replies
                .FirstOrDefault(i => i.Id == replyId);
            if(reply is null || reply.TicketId != ticketId)
            {
                throw new NotFoundException("Reply not found");
            }

            reply.ReplyDate = dto.ReplyDate;
            reply.ReplyDescription = dto.ReplyDescription;
            reply.ReplyProtocol = dto.ReplyProtocol;

            _context.SaveChanges();
        }

        private Ticket GetTicketById(int ticketId)
        {
            var ticket = _context
                .Tickets
                .Include(d => d.Replies)
                .FirstOrDefault(d => d.Id == ticketId);
            if (ticket is null)
                throw new NotFoundException("Ticket not found");

            return ticket;
        }
    }
}
