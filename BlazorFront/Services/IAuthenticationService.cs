using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public interface IAuthenticationService
    {
        Task<AuthResponseDto> Login(LoginDto userForAuthentication);
        Task Logout();
    }
}
