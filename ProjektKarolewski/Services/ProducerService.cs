using AutoMapper;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Exceptions;
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
        int Create(ProducerDto dto);
        ProducerDto GetById(int producerId);
        void RemoveById(int producerId);
        void Update(int producerId, ProducerDto dto);
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

        public int Create(ProducerDto dto)
        {

            var producer = _mapper.Map<Producer>(dto);

            _context.Producers.Add(producer);
            _context.SaveChanges();

            return producer.Id;
        }

        public ProducerDto GetById(int producerId)
        {

            var producer = _context.Producers
                .FirstOrDefault(i => i.Id == producerId);
            if (producer is null)
            {
                throw new NotFoundException("Service not found");
            }

            var producerDto = _mapper.Map<ProducerDto>(producer);
            return producerDto;
        }

        public void RemoveById(int producerId)
        {

            var producer = _context.Producers
                .FirstOrDefault(i => i.Id == producerId);
            if (producer is null)
            {
                throw new NotFoundException("Service not found");
            }

            var producerDto = _mapper.Map<ProducerDto>(producer);
            _context.Remove(producer);
            _context.SaveChanges();
        }

        public void Update(int producerId, ProducerDto dto)
        {
            var producer = _context.Producers
                .FirstOrDefault(i => i.Id == producerId);
            if (producer is null)
            {
                throw new NotFoundException("Service not found");
            }

            producer.Name = dto.Name;

            _context.SaveChanges();
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