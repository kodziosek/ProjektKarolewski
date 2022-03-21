using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class ServiceService : IServiceService
    {
        private readonly HttpClient httpClient;

        public ServiceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ServiceDto>> GetServices()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ServiceDto>>("api/service");
        }

        public async Task<IEnumerable<ServiceDto>> GetServiceById(int serviceId)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ServiceDto>>($"api/service/{serviceId}");
        }
        public async Task<ServiceDto> AddService(ServiceDto service)
        {
            var response = await httpClient.PostAsJsonAsync<ServiceDto>($"api/service", service);
            return await response.Content.ReadFromJsonAsync<ServiceDto>();
        }
        public async Task DeleteService(int serviceId)
        {
            await httpClient.DeleteAsync($"api/producer/{serviceId}");
        }
        public async Task<ServiceDto> UpdateService(ServiceDto service, int serviceId)
        {
            var response = await httpClient.PutAsJsonAsync<ServiceDto>($"api/service/{serviceId}", service);
            return await response.Content.ReadFromJsonAsync<ServiceDto>();
        }

    }
}
