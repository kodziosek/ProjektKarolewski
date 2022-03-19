using Microsoft.AspNetCore.Mvc;
using ProjektKarolewski.Models;
using ProjektKarolewski.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Controllers
{
    [ApiController]
    public class NotificationController : ControllerBase
    {

        private readonly IInspectionService _inspectionService;
        private readonly ITicketService _ticketService;

        public NotificationController(IInspectionService inspectionService, ITicketService ticketService)
        {
            _inspectionService = inspectionService;
            _ticketService = ticketService;
        }
        [Route("api/notifications/inspections")]
        [HttpGet]
        public ActionResult<List<InspectionDto>> Get()
        {
            var result = _inspectionService.GetAll();
            return Ok(result);
        }
        [Route("api/notifications/tickets")]
        [HttpGet]
        public ActionResult<List<TicketDto>> GetTickets()
        {
            var result = _ticketService.GetAll();
            return Ok(result);
        }
    }
}
