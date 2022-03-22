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

    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();
    }
    public class RoleService : IRoleService
    {
        private readonly ProjektDbContext _context;
        private readonly IMapper _mapper;

        public RoleService(ProjektDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<RoleDto> GetAll()
        {
            var roles = _context
                .Roles
                .ToList();

            var roleDtos = _mapper.Map<List<RoleDto>>(roles);

            return roleDtos;
        }
    }
}
