using AutoMapper;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Services
{

    public interface IProducerService
    {
        IEnumerable<ProducerDto> GetAll();
    }
    public class ProducerService : IProducerService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public ProducerService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ProducerDto> GetAll()
        {
            var producers = _context
                .Producers
                .ToList();

            var producerDtos = _mapper.Map<List<ProducerDto>>(producers);

            return producerDtos;
        }
    }
}