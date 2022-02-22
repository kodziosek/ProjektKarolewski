using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjektKarolewski.Entities;
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
