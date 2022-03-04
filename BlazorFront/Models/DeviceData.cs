using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFront.Models
{
    public class DeviceData
    {


        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
       // [Required(ErrorMessage = "Pole nie może być puste")]
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string Name { get; set; }
        [JsonProperty("NameInPassport")]
        //[Required(ErrorMessage = "Pole nie może być puste")]
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string NameInPassport { get; set; }
        [JsonProperty("AcquisitionDate")]
       // [Required(ErrorMessage = "Pole nie może być puste")]
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string AcquisitionDate { get; set; }
        [JsonProperty("ProductionDate")]
        //[Required(ErrorMessage = "Pole nie może być puste")]
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string ProductionDate { get; set; }
        [JsonProperty("PassportNumber")]
       // [Required(ErrorMessage = "Pole nie może być puste")]
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string PassportNumber { get; set; }
        [JsonProperty("InventoryNumber")]
        //[Required(ErrorMessage = "Pole nie może być puste")]
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string InventoryNumber { get; set; }
        [JsonProperty("SerialNumber")]
        //[Required(ErrorMessage = "Pole nie może być puste")]
        [MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
        public string SerialNumber { get; set; }
        [JsonProperty("Comments")]
        //[Required(ErrorMessage = "Pole nie może być puste")]
        //[MinLength(3, ErrorMessage = "Pole musi zawierać minimum 3 znaki")]
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
