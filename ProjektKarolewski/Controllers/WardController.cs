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
    [Route("api/ward")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }

        [HttpDelete("{wardId}")]
        public ActionResult<WardDto> Delete([FromRoute] int wardId)
        {
            _wardService.RemoveById(wardId);

            return NoContent();
        }

        [HttpPut("{wardId}")]
        public ActionResult<WardDto> Update([FromRoute] int wardId, [FromBody] WardDto dto)
        {
            _wardService.Update(wardId, dto);

            return Created($"api/ward/{wardId}", JObject.Parse("{'status': 200}"));
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateWardDto dto)
        {
            var newWardId = _wardService.Create(dto);

            return Created($"api/ward/{newWardId}", JObject.Parse("{'status': 200}"));
        }

        [HttpGet("{wardId}")]
        public ActionResult<WardDto> Get([FromRoute] int wardId)
        {
            WardDto ward = _wardService.GetById(wardId);
            return Ok(ward);
        }


        [HttpGet]
        public ActionResult<IEnumerable<WardDto>> GetAll()
        {

            var wardDtos = _wardService.GetAll();

            return Ok(wardDtos);
        }
    }
}
