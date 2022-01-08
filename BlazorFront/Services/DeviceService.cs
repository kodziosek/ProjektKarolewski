
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Newtonsoft.Json;
using BlazorFront.Models;

namespace BlazorFront.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly HttpClient httpClient;

        public DeviceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<DeviceResults> GetDevices()
        {
            var response = await httpClient.GetAsync("api/device?pageSize=1000&pageNumber=1");
            var json = await response.Content.ReadAsStringAsync();
            DeviceResults devices = JsonConvert.DeserializeObject<DeviceResults>(json);
            return devices;
        }
         public async Task<DeviceData> AddDevice(DeviceData device)
        {
            var response = await httpClient.PostAsJsonAsync<DeviceData>("api/device", device);
            return await response.Content.ReadFromJsonAsync<DeviceData>();
        }
        public async Task DeleteDevice(int deviceId)
        {
            await httpClient.DeleteAsync($"api/device/{deviceId}");
        }
        public async Task<DeviceData> UpdateDevice(DeviceData device)
        {
            var response = await httpClient
                .PutAsJsonAsync<DeviceData>($"api/device/{device.Id}", device);
            return await response.Content.ReadFromJsonAsync<DeviceData>();
        }
    }
}
