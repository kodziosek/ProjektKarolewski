using AutoMapper;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Services
{

    public interface IWardService
    {
        IEnumerable<WardDto> GetAll();
    }
    public class WardService : IWardService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public WardService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<WardDto> GetAll()
        {
            var wards = _context
                .Wards
                .ToList();

            var wardDtos = _mapper.Map<List<WardDto>>(wards);

            return wardDtos;
        }
    }
}
