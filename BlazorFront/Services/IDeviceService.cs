using BlazorFront.Models;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public interface IDeviceService
    {
       Task<DeviceResults> GetDevices();
        Task<DeviceData> AddDevice(DeviceData device);
        Task DeleteDevice(int deviceId);
        Task<DeviceData> UpdateDevice(DeviceData device);
        Task<DeviceDto> GetDeviceById(int Id);
    }
}
