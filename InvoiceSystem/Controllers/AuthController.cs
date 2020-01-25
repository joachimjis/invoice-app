using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InvoiceSystem.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceSystem.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public AuthController(IAuthenticationService _authenticationService)
        {
            authenticationService = _authenticationService;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var token = authenticationService.AuthenticateUser(user);

            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            } else
            {
                return Ok(new { Token = token });
            }
        }
    }
}
