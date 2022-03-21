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
    [Route("api/producer")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpDelete("{producerId}")]
        public ActionResult<ProducerDto> Delete([FromRoute] int producerId)
        {
            _producerService.RemoveById(producerId);

            return NoContent();
        }

        [HttpPut("{producerId}")]
        public ActionResult<ProducerDto> Update([FromRoute] int producerId, [FromBody] ProducerDto dto)
        {
            _producerService.Update(producerId, dto);

            return Created($"api/producer/{producerId}", JObject.Parse("{'status': 200}"));
        }

        [HttpPost]
        public ActionResult Post( [FromBody] ProducerDto dto)
        {
            var newProducerId = _producerService.Create(dto);

            return Created($"api/producer/{newProducerId}", JObject.Parse("{'status': 200}"));
        }

        [HttpGet("{producerId}")]
        public ActionResult<ProducerDto> Get([FromRoute] int producerId)
        {
            ProducerDto producer = _producerService.GetById(producerId);
            return Ok(producer);
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProducerDto>> GetAll()
        {

            var producerDtos = _producerService.GetAll();

            return Ok(producerDtos);
        }
    }
}
