using ProjektKarolewski.Entities;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public interface IWardService
    {
        Task<IEnumerable<WardDto>> GetWards();
        Task<IEnumerable<WardDto>> GetWardById(int wardId);
        Task<WardDto> AddWard(WardDto ward);
        Task DeleteWard(int wardId);
        Task<WardDto> UpdateWard(WardDto ward, int wardId);
    }
}
