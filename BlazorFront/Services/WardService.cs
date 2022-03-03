﻿using ProjektKarolewski.Entities;
using ProjektKarolewski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class WardService : IWardService
    {
        private readonly HttpClient httpClient;

        public WardService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<WardDto>> GetWards()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<WardDto>>("api/ward");
        }
    }
}
