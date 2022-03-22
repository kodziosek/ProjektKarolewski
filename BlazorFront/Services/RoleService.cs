using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient httpClient;

        public RoleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<RoleDto>> GetRoles()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<RoleDto>>("api/role");
        }
    }
}
