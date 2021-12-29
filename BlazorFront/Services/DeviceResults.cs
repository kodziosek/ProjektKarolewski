using BlazorFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Services
{
    public class DeviceResults
    {
        [JsonProperty("items")]
        public List<DeviceData> devices { get; set; }
        [JsonProperty("totalPages")]
        public int totalPages { get; set; }
        [JsonProperty("itemsFrom")]
        public int itemsFrom { get; set; }
        [JsonProperty("itemsTo")]
        public int itemsTo { get; set; }
        [JsonProperty("totalItemsCount")]
        public int totalItemsCount { get; set; }
    }
}
