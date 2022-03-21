using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Exceptions;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Services
{

    public interface IServiceService
    {
        IEnumerable<ServiceDto> GetAll();
        int Create(CreateServiceDto dto);
        ServiceDto GetById(int serviceId);
        void RemoveById(int serviceId);
        void Update(int serviceId, ServiceDto dto);
    }
    public class ServiceService : IServiceService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public ServiceService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(CreateServiceDto dto)
        {

            var service = _mapper.Map<Service>(dto);

            _context.Services.Add(service);
            _context.SaveChanges();

            return service.Id;
        }

        public ServiceDto GetById(int serviceId)
        {

            var service = _context.Services
                .FirstOrDefault(i => i.Id == serviceId);
            if (service is null)
            {
                throw new NotFoundException("Service not found");
            }

            var serviceDto = _mapper.Map<ServiceDto>(service);
            return serviceDto;
        }

        public void RemoveById(int serviceId)
        {

            var service = _context.Services
                .FirstOrDefault(i => i.Id == serviceId);
            if (service is null)
            {
                throw new NotFoundException("Service not found");
            }

            var serviceDto = _mapper.Map<ServiceDto>(service);
            _context.Remove(service);
            _context.SaveChanges();
        }

        public void Update(int serviceId, ServiceDto dto)
        {
            var service = _context.Services
                .FirstOrDefault(i => i.Id == serviceId);
            if (service is null)
            {
                throw new NotFoundException("Service not found");
            }

            service.City = dto.City;
            service.ServiceName = dto.ServiceName;
            service.Street = dto.Street;
            service.EmailAddress = dto.EmailAddress;
            service.ContractId = dto.ContractId;
            service.PhoneNumber = dto.PhoneNumber;
            service.PostalCode = dto.PostalCode;

            _context.SaveChanges();
        }


        public IEnumerable<ServiceDto> GetAll()
        {
            var services = _context
                .Services
                .Include(s => s.Contract)
                .ToList();

            var serviceDtos = _mapper.Map<List<ServiceDto>>(services);

            return serviceDtos;
        }
    }
}
