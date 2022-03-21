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

    public interface IContractService
    {
        IEnumerable<ContractDto> GetAll();
    }
    public class ContractService : IContractService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public ContractService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      
        public IEnumerable<ContractDto> GetAll()
        {
            var contracts = _context
                .Contracts
                .ToList();

            var contractDtos = _mapper.Map<List<ContractDto>>(contracts);

            return contractDtos;
        }
    }
}
