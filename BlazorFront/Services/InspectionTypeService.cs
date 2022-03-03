using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class InspectionTypeService : IInspectionTypeService
    {
        private readonly HttpClient httpClient;

        public InspectionTypeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<InspectionTypeDto>> GetInspectionTypes()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<InspectionTypeDto>>("api/inspectionType");
        }
    }
}
