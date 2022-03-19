using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public interface IReplyService
    {
        Task<IEnumerable<ReplyDto>> GetReplyByTicket(int deviceId, int ticketId);
        Task<IEnumerable<ReplyDto>> GetReplyById(int deviceId, int ticketId, int replyId);
        Task<ReplyDto> AddReply(ReplyDto reply, int deviceId, int ticketId);
        Task DeleteReply(int ticketId, int deviceId, int replyId);
        Task<ReplyDto> UpdateReply(ReplyDto reply, int deviceId, int ticketId, int replyId);
    }
}
