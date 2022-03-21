using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class ContractService : IContractService
    {
        private readonly HttpClient httpClient;

        public ContractService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ContractDto>> GetContracts()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<ContractDto>>("api/contract");
        }
    }
}
