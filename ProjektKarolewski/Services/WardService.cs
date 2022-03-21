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

    public interface IWardService
    {
        IEnumerable<WardDto> GetAll();
        int Create(CreateWardDto dto);
        WardDto GetById(int wardId);
        void RemoveById(int wardId);
        void Update(int wardId, WardDto dto);
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

        public int Create(CreateWardDto dto)
        {

            var ward = _mapper.Map<Ward>(dto);

            _context.Wards.Add(ward);
            _context.SaveChanges();

            return ward.Id;
        }

        public WardDto GetById(int wardId)
        {

            var ward = _context.Wards
                .FirstOrDefault(i => i.Id == wardId);
            if (ward is null)
            {
                throw new NotFoundException("Ward not found");
            }

            var wardDto = _mapper.Map<WardDto>(ward);
            return wardDto;
        }

        public void RemoveById(int wardId)
        {

            var ward = _context.Wards
                .FirstOrDefault(i => i.Id == wardId);
            if (ward is null)
            {
                throw new NotFoundException("Ward not found");
            }

            var wardDto = _mapper.Map<WardDto>(ward);
            _context.Remove(ward);
            _context.SaveChanges();
        }

        public void Update(int wardId, WardDto dto)
        {
            var ward = _context.Wards
                .FirstOrDefault(i => i.Id == wardId);
            if (ward is null)
            {
                throw new NotFoundException("Ward not found");
            }

            ward.Name = dto.Name;

            _context.SaveChanges();
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
