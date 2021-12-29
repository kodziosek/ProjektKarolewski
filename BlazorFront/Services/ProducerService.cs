using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class ProducerService : IProducerService
    {
        private readonly HttpClient httpClient;

        public ProducerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ProducerDto>> GetProducers()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ProducerDto>>("api/producer");
        }
    }
}
