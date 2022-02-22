using AutoMapper;
using ProjektKarolewski.Entities;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Services
{

    public interface IInspectionTypeService
    {
        IEnumerable<InspectionTypeDto> GetAll();
    }
    public class InspectionTypeService : IInspectionTypeService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public InspectionTypeService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<InspectionTypeDto> GetAll()
        {
            var inspectiontypes = _context
                .InspectionTypes
                .ToList();

            var inspectionTypesDtos = _mapper.Map<List<InspectionTypeDto>>(inspectiontypes);

            return inspectionTypesDtos;
        }
    }
}
