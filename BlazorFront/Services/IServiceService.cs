using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceDto>> GetServices();
        Task<IEnumerable<ServiceDto>> GetServiceById(int serviceId);
        Task<ServiceDto> AddService(ServiceDto service);
        Task DeleteService(int serviceId);
        Task<ServiceDto> UpdateService(ServiceDto service, int serviceId);
    }
}
