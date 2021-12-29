using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Exceptions;
using ProjektKarolewski.Models;

namespace ProjektKarolewski.Services
{
    public interface IDeviceService
    {
        DeviceDto GetById(int id);
        PagedResult<DeviceDto> GetAll(DeviceQuery query);
        int Create(CreateDeviceDto dto);
        void Delete(int id);
        void Update(int id, UpdateDeviceDto dto);
    }

    public class DeviceService : IDeviceService
    {
        private readonly ProjektDbContext _dbContext;
        private readonly IMapper _mapper;
        public ILogger<DeviceService> _logger;

        public DeviceService(ProjektDbContext dbContext, IMapper mapper, ILogger<DeviceService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public void Update(int id, UpdateDeviceDto dto)
        {
            var device = _dbContext
                .Devices
                .FirstOrDefault((d => d.Id == id));
            if (device is null)
                throw new NotFoundException("Device not found");

            device.Name = dto.Name;
            device.NameInPassport = dto.NameInPassport;
            device.AcquisitionDate = dto.AcquisitionDate;
            device.ProductionDate = dto.ProductionDate;
            device.PassportNumber = dto.PassportNumber;
            device.InventoryNumber = dto.InventoryNumber;
            device.SerialNumber = dto.SerialNumber;
            device.Comments = dto.Comments;
            device.WardId = dto.WardId;
            device.ProducerId = dto.ProducerId;

            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            _logger.LogWarning($"Device with id: {id} DELETE action invoked");
            var device = _dbContext
                .Devices
                .FirstOrDefault((d => d.Id == id));

            if (device is null)
                throw new NotFoundException("Device not found");

            _dbContext.Devices.Remove(device);
            _dbContext.SaveChanges();

        }

        public DeviceDto GetById(int id)
        {
            var device = _dbContext
                .Devices
                .Include(d => d.Ward)
                .Include(d => d.Producer)
                .FirstOrDefault((d => d.Id == id));

            if (device is null)
                throw new NotFoundException("Device not found");

            var result = _mapper.Map<DeviceDto>(device);
            return result;
        }

        public PagedResult<DeviceDto> GetAll(DeviceQuery query)
        {
            var baseQuery = _dbContext
                .Devices
                .Include(d => d.Ward)
                .Include(d => d.Producer)
                .Where(d => query.SearchPhrase == null || d.Name.ToLower().Contains(query.SearchPhrase.ToLower())
                        || d.Comments.ToLower().Contains(query.SearchPhrase.ToLower()));

            if(!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Device, object>>>
                    {
                         {nameof(Device.Name), d => d.Name},
                         {nameof(Device.Producer), d => d.Producer},
                         {nameof(Device.Comments), d => d.Comments},
                    };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC
                     ? baseQuery.OrderBy(selectedColumn)
                     : baseQuery.OrderByDescending(selectedColumn);
            }

            var devices = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var devicesDtos = _mapper.Map<List<DeviceDto>>(devices);


            var result = new PagedResult<DeviceDto>(devicesDtos, totalItemsCount, query.PageSize, query.PageNumber);
            return result;
        }

        public int Create(CreateDeviceDto dto)
        {
            var device = _mapper.Map<Device>(dto);

            device.ProducerId = dto.ProducerId;
            device.WardId = dto.WardId;


            _dbContext.Devices.Add(device);
            _dbContext.SaveChanges();

            return device.Id;
        }
    }
}
