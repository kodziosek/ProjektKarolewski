using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> UpdateUser(UserDto user, int userId);
        Task<RegisterUserDto> ChangePassword(RegisterUserDto user, int userId);
        Task<RegisterUserDto> AddWard(RegisterUserDto user);
    }
}
