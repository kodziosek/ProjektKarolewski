using Newtonsoft.Json;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class ReplyService : IReplyService
    {
        private readonly HttpClient httpClient;

        public ReplyService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ReplyDto>> GetReplyByTicket(int deviceId, int ticketId)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ReplyDto>>($"api/device/{deviceId}/ticket/{ticketId}/reply");
        }
        public async Task<IEnumerable<ReplyDto>> GetReplyById(int deviceId, int ticketId, int replyId)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ReplyDto>>($"api/device/{deviceId}/ticket/{ticketId}/reply/{replyId}");
        }
        public async Task<ReplyDto> AddReply(ReplyDto reply, int deviceId, int ticketId)
        {

            var response = await httpClient.PostAsJsonAsync<ReplyDto>($"api/device/{deviceId}/ticket/{ticketId}/reply", reply);
            return await response.Content.ReadFromJsonAsync<ReplyDto>();
        }
        public async Task DeleteReply(int ticketId, int deviceId, int replyId)
        {
            await httpClient.DeleteAsync($"api/device/{deviceId}/ticket/{ticketId}/reply/{replyId}");
        }
        public async Task<ReplyDto> UpdateReply(ReplyDto reply, int deviceId, int ticketId, int replyId)
        {
            var response = await httpClient.PutAsJsonAsync<ReplyDto>($"api/device/{deviceId}/ticket/{ticketId}/reply/{replyId}", reply);
            return await response.Content.ReadFromJsonAsync<ReplyDto>();
        }
    }

}
