using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Models
{
    public class DeviceData
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("NameInPassport")]
        public string NameInPassport { get; set; }
        [JsonProperty("AcquisitionDate")]
        public string AcquisitionDate { get; set; }
        [JsonProperty("ProductionDate")]
        public string ProductionDate { get; set; }
        [JsonProperty("PassportNumber")]
        public string PassportNumber { get; set; }
        [JsonProperty("InventoryNumber")]
        public string InventoryNumber { get; set; }
        [JsonProperty("SerialNumber")]
        public string SerialNumber { get; set; }
        [JsonProperty("Comments")]
        public string Comments { get; set; }
        [JsonProperty("Ward")]
        public string Ward { get; set; }
        [JsonProperty("Producer")]
        public string Producer { get; set; }
        [JsonProperty("ProducerId")]
        public int ProducerId { get; set; }
        [JsonProperty("WardId")]
        public int WardId { get; set; }

    }
}
