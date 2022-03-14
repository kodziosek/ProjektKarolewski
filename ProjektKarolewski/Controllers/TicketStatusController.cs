using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjektKarolewski.Models;
using ProjektKarolewski.Services;

namespace ProjektKarolewski.Controllers
{
    [Route("api/ticketstatus")]
    [ApiController]
    public class TicketStatusController :ControllerBase
    {
        private readonly ITicketStatusService _ticketStatusService;

        public TicketStatusController(ITicketStatusService ticketStatusService)
        {
            _ticketStatusService = ticketStatusService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TicketStatusDto>> GetAll()
        {

            var ticketStatusDtos = _ticketStatusService.GetAll();

            return Ok(ticketStatusDtos);
        }
    }
}
