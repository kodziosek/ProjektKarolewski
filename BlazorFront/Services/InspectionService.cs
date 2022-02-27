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
    public class InspectionService : IInspectionService
    {
        private readonly HttpClient httpClient;

        public InspectionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<InspectionDto>> GetInspectionByDevice(int deviceId)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<InspectionDto>>($"api/device/{deviceId}/inspection/");
        }
        public async Task<InspectionDto> AddInspection(InspectionDto inspection)
        {

            var response = await httpClient.PostAsJsonAsync<InspectionDto>("api/device", inspection);
            return await response.Content.ReadFromJsonAsync<InspectionDto>();
        }
        public async Task DeleteInspection(int inspectionId, int deviceId)
        {
            await httpClient.DeleteAsync($"api/device/{deviceId}/inspection/{inspectionId}");
        }
        public async Task<InspectionDto> UpdateInspection(InspectionDto inspection, int deviceId, int inspectionId)
        {
            var response = await httpClient.PutAsJsonAsync<InspectionDto>($"api/device/{deviceId}/inspection/{inspectionId}", inspection);
            return await response.Content.ReadFromJsonAsync<InspectionDto>();
        }
    }

}
