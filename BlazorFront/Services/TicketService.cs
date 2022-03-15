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
    public class TicketService : ITicketService
    {
        private readonly HttpClient httpClient;

        public TicketService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<TicketDto>> GetTicketByDevice(int deviceId)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<TicketDto>>($"api/device/{deviceId}/ticket/");
        }
        public async Task<IEnumerable<TicketDto>> GetTicketById(int deviceId, int ticketId)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<TicketDto>>($"api/device/{deviceId}/ticket/{ticketId}");
        }
        public async Task<TicketDto> AddTicket(TicketDto ticket, int deviceId)
        {

            var response = await httpClient.PostAsJsonAsync<TicketDto>($"api/device/{deviceId}/ticket", ticket);
            return await response.Content.ReadFromJsonAsync<TicketDto>();
        }
        public async Task DeleteTicket(int ticketId, int deviceId)
        {
            await httpClient.DeleteAsync($"api/device/{deviceId}/ticket/{ticketId}");
        }
        public async Task<TicketDto> UpdateTicket(TicketDto ticket, int deviceId, int ticketId)
        {
            var response = await httpClient.PutAsJsonAsync<TicketDto>($"api/device/{deviceId}/ticket/{ticketId}", ticket);
            return await response.Content.ReadFromJsonAsync<TicketDto>();
        }
    }

}
