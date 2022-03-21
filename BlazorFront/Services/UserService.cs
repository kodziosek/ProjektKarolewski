using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<UserDto>>("api/account");
        }
        public async Task<UserDto> UpdateUser(UserDto user, int userId)
        {
            var response = await httpClient.PutAsJsonAsync<UserDto>($"api/account/{userId}", user);
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }
        public async Task<RegisterUserDto> ChangePassword(RegisterUserDto user, int userId)
        {
            var response = await httpClient.PutAsJsonAsync<RegisterUserDto>($"api/account/changePassword/{userId}", user);
            return await response.Content.ReadFromJsonAsync<RegisterUserDto>();
        }
        public async Task<RegisterUserDto> AddWard(RegisterUserDto user)
        {
            var response = await httpClient.PostAsJsonAsync<RegisterUserDto>($"api/user/", user);
            return await response.Content.ReadFromJsonAsync<RegisterUserDto>();
        }
    }
}
