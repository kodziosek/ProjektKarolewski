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
    [Route("api/device/{deviceId}/inspection")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
        private readonly IInspectionService _inspectionService;

        public InspectionController(IInspectionService inspectionService)
        {
            _inspectionService = inspectionService;
        }

        [HttpDelete]
        public ActionResult Delete ([FromRoute] int deviceId)
        {
            _inspectionService.RemoveAll(deviceId);

            return NoContent();
        }

        [HttpDelete("{inspectionId}")]
        public ActionResult<InspectionDto> Delete([FromRoute] int deviceId, [FromRoute] int inspectionId)
        {
            _inspectionService.RemoveById(deviceId, inspectionId);

            return NoContent();
        }

        [HttpPut("{inspectionId}")]
        public ActionResult<InspectionDto> Update([FromRoute] int deviceId, [FromBody] InspectionDto dto, [FromRoute] int inspectionId)
        {
            _inspectionService.Update(deviceId, dto, inspectionId);

            return Created($"api/device/{deviceId}/inspection/{inspectionId}", JObject.Parse("{'status': 200}"));
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int deviceId,[FromBody] CreateInspectionDto dto)
        {
            var newInspectionId = _inspectionService.Create(deviceId, dto);

            return Created($"api/device/{deviceId}/inspection/{newInspectionId}", JObject.Parse("{'status': 200}"));
        }

        [HttpGet("{inspectionId}")]
        public ActionResult<InspectionDto> Get([FromRoute] int deviceId, [FromRoute] int inspectionId)
        {
            InspectionDto inspection = _inspectionService.GetById(deviceId, inspectionId);
            return Ok(inspection);
        }
        [HttpGet]
        public ActionResult<List<InspectionDto>> Get([FromRoute] int deviceId)
        {
            var result = _inspectionService.GetAll(deviceId);
            return Ok(result);
        }
    }
}
