using ProjektKarolewski.Entities;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class WardService : IWardService
    {
        private readonly HttpClient httpClient;

        public WardService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<WardDto>> GetWards()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<WardDto>>("api/ward");
        }

        public async Task<IEnumerable<WardDto>> GetWardById(int wardId)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<WardDto>>($"api/ward/{wardId}");
        }
        public async Task<WardDto> AddWard(WardDto ward)
        {
            var response = await httpClient.PostAsJsonAsync<WardDto>($"api/ward/", ward);
            return await response.Content.ReadFromJsonAsync<WardDto>();
        }
        public async Task DeleteWard(int wardId)
        {
            await httpClient.DeleteAsync($"api/ward/{wardId}");
        }
        public async Task<WardDto> UpdateWard(WardDto ward, int wardId)
        {
            var response = await httpClient.PutAsJsonAsync<WardDto>($"api/producer/{wardId}", ward);
            return await response.Content.ReadFromJsonAsync<WardDto>();
        }

    }
}
