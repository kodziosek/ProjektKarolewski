using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public interface IInspectionService
    {
        Task<IEnumerable<InspectionDto>> GetInspectionByDevice(int deviceId);
        Task<InspectionDto> AddDevice(InspectionDto inspection);
        Task DeleteInspection(int inspectionId, int deviceId);
       // Task<InspectionDto> UpdateInspection(InspectionDto device);

    }
}
