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
        Task<IEnumerable<InspectionDto>> GetInspectionById(int deviceId, int inspectionId);
        Task<InspectionDto> AddInspection(InspectionDto inspection, int deviceId);
        Task DeleteInspection(int inspectionId, int deviceId);
       Task<InspectionDto> UpdateInspection(InspectionDto inspection, int deviceId, int inspectionId);


    }
}
