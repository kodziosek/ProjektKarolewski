using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjektKarolewski.Models;
using ProjektKarolewski.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpDelete("{serviceId}")]
        public ActionResult<ServiceDto> Delete([FromRoute] int serviceId)
        {
            _serviceService.RemoveById(serviceId);

            return NoContent();
        }

        [HttpPut("{serviceId}")]
        public ActionResult<ServiceDto> Update([FromRoute] int serviceId, [FromBody] ServiceDto dto)
        {
            _serviceService.Update(serviceId, dto);

            return Created($"api/service/{serviceId}", JObject.Parse("{'status': 200}"));
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateServiceDto dto)
        {
            var newServiceId = _serviceService.Create(dto);

            return Created($"api/service/{newServiceId}", JObject.Parse("{'status': 200}"));
        }

        [HttpGet("{serviceId}")]
        public ActionResult<ServiceDto> Get([FromRoute] int serviceId)
        {
            ServiceDto service = _serviceService.GetById(serviceId);
            return Ok(service);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServiceDto>> GetAll()
        {

            var serviceDtos = _serviceService.GetAll();

            return Ok(serviceDtos);
        }
    }
}
