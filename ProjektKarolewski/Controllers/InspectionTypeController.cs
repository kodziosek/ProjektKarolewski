using Microsoft.AspNetCore.Mvc;
using ProjektKarolewski.Models;
using ProjektKarolewski.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektKarolewski.Controllers
{
    [Route("api/inspectionType")]
    [ApiController]
    public class InspectionTypeController : ControllerBase
    {
        private readonly IInspectionTypeService _inspectionTypeService;

        public InspectionTypeController(IInspectionTypeService inspectionTypeService)
        {
            _inspectionTypeService = inspectionTypeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<InspectionTypeDto>> GetAll()
        {

            var inspectionTypeDtos = _inspectionTypeService.GetAll();

            return Ok(inspectionTypeDtos);
        }
    }
}
