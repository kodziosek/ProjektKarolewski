using Blazored.LocalStorage;
using BlazorFront.AuthProviders;
using Microsoft.AspNetCore.Components.Authorization;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<AuthResponseDto> Login(LoginDto userforAthentication)
        {
            var content = JsonSerializer.Serialize(userforAthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            AuthResponseDto responseAuth = new AuthResponseDto();

            var authResult = await httpClient.PostAsync("api/account/login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            responseAuth.Token = authContent;

            if (!authResult.IsSuccessStatusCode)
            {
                responseAuth.ErrorMessage = "Niepoprawny login lub hasło!";
                responseAuth.IsAuthSuccessful = false;
                return responseAuth;
            }

            await _localStorage.SetItemAsync("authToken", authContent);
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(responseAuth.Token);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authContent);
            return new AuthResponseDto { IsAuthSuccessful = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
