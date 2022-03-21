using Microsoft.AspNetCore.Http;
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
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {

            var userDtos = _accountService.GetAll();

            return Ok(userDtos);
        }

        [HttpPut("{userId}")]
        public ActionResult<UserDto> Update([FromRoute] int userId, [FromBody] UserDto dto)
        {
            _accountService.Update(userId, dto);

            return Created($"api/account/{userId}", JObject.Parse("{'status': 200}"));
        }

        [HttpPut("changePassword/{userId}")]
        public ActionResult<RegisterUserDto> ChangePassword([FromRoute] int userId, [FromBody] RegisterUserDto dto)
        {
            _accountService.ChangePassword(userId, dto);

            return Created($"api/account/changePassword/{userId}", JObject.Parse("{'status': 200}"));
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);

            return Ok(token);
        }
    }
}
