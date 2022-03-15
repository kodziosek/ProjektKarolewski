using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class TicketStatusService : ITicketStatusService
    {
        private readonly HttpClient httpClient;

        public TicketStatusService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<TicketStatusDto>> GetTicketStatuses()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<TicketStatusDto>>("api/ticketstatus");
        }
    }
}
