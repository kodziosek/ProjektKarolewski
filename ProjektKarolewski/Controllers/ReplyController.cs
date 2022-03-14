using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjektKarolewski.Models;
using ProjektKarolewski.Services;

namespace ProjektKarolewski.Controllers
{
    [Route("api/device/{deviceId}/ticket/{ticketId}/reply")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;

        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        [HttpDelete("{replyId}")]
        public ActionResult<ReplyDto> Delete([FromRoute] int ticketId, [FromRoute] int replyId)
        {
            _replyService.RemoveById(ticketId, replyId);

            return NoContent();
        }

        [HttpPut("{replyId}")]
        public ActionResult<ReplyDto> Update([FromRoute] int deviceId, [FromRoute] int ticketId, [FromBody] ReplyDto dto, [FromRoute] int replyId)
        {
            _replyService.Update(ticketId, dto, replyId);

            return Created($"api/device/{deviceId}/ticket/{ticketId}/reply/{replyId}", JObject.Parse("{'status': 200}"));
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int deviceId, [FromRoute] int ticketId, [FromBody] CreateReplyDto dto)
        {
            var newReplyId = _replyService.Create(ticketId, dto);

            return Created($"api/device/{deviceId}/ticket/{ticketId}/reply/{newReplyId}", JObject.Parse("{'status': 200}"));
        }

        [HttpGet("{replyId}")]
        public ActionResult<ReplyDto> Get([FromRoute] int ticketId, [FromRoute] int replyId)
        {
            ReplyDto reply = _replyService.GetById(ticketId, replyId);
            return Ok(reply);
        }
        [HttpGet]
        public ActionResult<List<ReplyDto>> Get([FromRoute] int ticketId)
        {
            var result = _replyService.GetAll(ticketId);
            return Ok(result);
        }
    }
}
