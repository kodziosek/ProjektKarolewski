using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public ActionResult<IEnumerable<WardDto>> GetAll()
        {

            var wardDtos = _wardService.GetAll();

            return Ok(wardDtos);
        }
    }
}
