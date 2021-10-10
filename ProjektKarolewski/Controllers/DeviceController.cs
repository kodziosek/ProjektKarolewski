using Microsoft.AspNetCore.Mvc;
using ProjektKarolewski.Entities;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjektKarolewski.Models;
using ProjektKarolewski.Services;
using Microsoft.AspNetCore.Authorization;

namespace ProjektKarolewski.Controllers
{
    [Route("api/device")]
    [ApiController]
    //[Authorize]
    public class ProjektController : ControllerBase
    {

        private readonly IDeviceService _deviceService;

        public ProjektController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult Update([FromBody] UpdateDeviceDto dto, [FromRoute]int id)
        {

            _deviceService.Update(id, dto);
      
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _deviceService.Delete(id);


            return NoContent();
        }


        [HttpPost]
        public ActionResult CreateDevice([FromBody] CreateDeviceDto dto)
        {

            var id = _deviceService.Create(dto);

            return Created($"/api/device/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeviceDto>> GetAll([FromQuery] DeviceQuery query)
        {
          
            var devicesDtos = _deviceService.GetAll(query);

            return Ok(devicesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<DeviceDto> Get([FromRoute] int id)
        {

            var device = _deviceService.GetById(id);

            return Ok(device);
        }
    }
}
