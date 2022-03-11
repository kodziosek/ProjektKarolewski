using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjektKarolewski.Models;
using ProjektKarolewski.Services;
using System.Collections.Generic;

namespace ProjektKarolewski.Controllers
{
    [Route("api/device/{deviceId}/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }


        [HttpDelete("{ticketId}")]
        public ActionResult<TicketDto> Delete([FromRoute] int deviceId, [FromRoute] int ticketId)
        {
            _ticketService.RemoveById(deviceId, ticketId);

            return NoContent();
        }

        [HttpPut("{ticketId}")]
        public ActionResult<TicketDto> Update([FromRoute] int deviceId, [FromBody] TicketDto dto, [FromRoute] int ticketId)
        {
            _ticketService.Update(deviceId, dto, ticketId);

            return Created($"api/device/{deviceId}/inspection/{ticketId}", JObject.Parse("{'status': 200}"));
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int deviceId, [FromBody] CreateTicketDto dto)
        {
            var newTicketId = _ticketService.Create(deviceId, dto);

            return Created($"api/device/{deviceId}/inspection/{newTicketId}", JObject.Parse("{'status': 200}"));
        }

        [HttpGet("{ticketId}")]
        public ActionResult<TicketDto> Get([FromRoute] int deviceId, [FromRoute] int ticketId)
        {
            TicketDto inspection = _ticketService.GetById(deviceId, ticketId);
            return Ok(inspection);
        }
        [HttpGet]
        public ActionResult<List<TicketDto>> Get([FromRoute] int deviceId)
        {
            var result = _ticketService.GetAll(deviceId);
            return Ok(result);
        }
    }
}
