//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;

//namespace BlazorFront.Services
//{
//    public class InspectionService : IInspectionService
//    {
//        private readonly HttpClient httpClient;

//        public InspectionService(HttpClient httpClient)
//        {
//            this.httpClient = httpClient;
//        }

//        public async Task<InspectionDto> GetInspectionByDevice(int deviceId)
//        {
//            return await httpClient.GetFromJsonAsync<IEnumerable<InspectionDto>>($"api/device/{deviceId}/inspection/");
//        }
//    }
//}
