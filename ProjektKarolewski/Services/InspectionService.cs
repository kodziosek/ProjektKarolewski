using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Exceptions;
using ProjektKarolewski.Models;

namespace ProjektKarolewski.Services
{

    public interface IInspectionService
    {
        int Create(int deviceId, CreateInspectionDto dto);
        InspectionDto GetById(int deviceId, int inspectionId);
        List<InspectionDto> GetAll(int deviceId);
        void RemoveAll(int deviceId);
        void RemoveById(int deviceId, int inspectionId);
    }
    public class InspectionService : IInspectionService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public InspectionService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int deviceId, CreateInspectionDto dto)
        {
            var device = GetDeviceById(deviceId);

            var inspection = _mapper.Map<Inspection>(dto);

            inspection.DeviceId = deviceId;
            inspection.InspectionTypeId = dto.InspectionTypeId;
            inspection.ServiceId = dto.ServiceId;
            _context.Inspections.Add(inspection);
            _context.SaveChanges();

            return inspection.Id;

        }

        public InspectionDto GetById(int deviceId, int inspectionId)
        {
            var device = GetDeviceById(deviceId);

            var inspection = _context.Inspections.FirstOrDefault(i => i.Id == inspectionId);
            if (inspection is null || inspection.DeviceId != deviceId)
            {
                throw new NotFoundException("Inspection not found");
            }

            var inspectionDto = _mapper.Map<InspectionDto>(inspection);
            return inspectionDto;
        }

        public List<InspectionDto> GetAll(int deviceId)
        {
            var device = GetDeviceById(deviceId);

            var inspectionDtos = _mapper.Map<List<InspectionDto>>(device.Inspections);

            return inspectionDtos;
        }

        public void RemoveAll(int deviceId)
        {
            var device = GetDeviceById(deviceId);
            _context.RemoveRange(device.Inspections);
            _context.SaveChanges();
        }

        public void RemoveById(int deviceId, int inspectionId)
        {
            var device = GetDeviceById(deviceId);

            var inspection = _context.Inspections.FirstOrDefault(i => i.Id == inspectionId);
            if (inspection is null || inspection.DeviceId != deviceId)
            {
                throw new NotFoundException("Inspection not found");
            }

            var inspectionDto = _mapper.Map<InspectionDto>(inspection);

            _context.Remove(inspection);
            _context.SaveChanges();
        }

        private Device GetDeviceById(int deviceId)
        {
            var device = _context
                .Devices
                .Include(d => d.Inspections)
                .FirstOrDefault(d => d.Id == deviceId);
            if (device is null)
                throw new NotFoundException("Device not found");

            return device;
        }
    }
}
