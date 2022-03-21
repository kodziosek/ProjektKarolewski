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

        public async Task<IEnumerable<ProducerDto>> GetProducerById(int producerId)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ProducerDto>>($"api/producer/{producerId}");
        }
        public async Task<ProducerDto> AddProducer(ProducerDto producer)
        {
            var response = await httpClient.PostAsJsonAsync<ProducerDto>($"api/producer", producer);
            return await response.Content.ReadFromJsonAsync<ProducerDto>();
        }
        public async Task DeleteProducer(int producerId)
        {
            await httpClient.DeleteAsync($"api/producer/{producerId}");
        }
        public async Task<ProducerDto> UpdateProducer(ProducerDto producer, int producerId)
        {
            var response = await httpClient.PutAsJsonAsync<ProducerDto>($"api/producer/{producerId}", producer);
            return await response.Content.ReadFromJsonAsync<ProducerDto>();
        }
    }
}
