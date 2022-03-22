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
        public async Task<UserDto> ChangePassword(UserDto user, int userId)
        {
            var response = await httpClient.PutAsJsonAsync<UserDto>($"api/account/changePassword/{userId}", user);
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }
        public async Task<UserDto> AddUser(UserDto user)
        {
            var response = await httpClient.PostAsJsonAsync<UserDto>($"api/account/register", user);
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }
        public async Task DeleteUser(int userId)
        {
            await httpClient.DeleteAsync($"api/account/{userId}");
        }
    }
}
