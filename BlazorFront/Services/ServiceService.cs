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

    }
}
