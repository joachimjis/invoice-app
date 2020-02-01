using System;
using InvoiceSystem.Business.IServices;
using InvoiceSystem.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceSystem.ApiHost.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async System.Threading.Tasks.Task<IActionResult> AuthenticateAsync([FromBody]User model)
        {
            try
            {
                var user = await _userService.AuthenticateAsync(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(user);
            }
            catch(Exception ex)
            {
                 throw;
            }
        }
    }
}
