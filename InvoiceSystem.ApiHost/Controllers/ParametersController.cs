using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InvoiceSystem.Business.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceSystem.ApiHost.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ParametersController : Controller
    {
        [HttpGet]
        public async Task<ParameterModel> GetAsync()
        {
            return new ParameterModel();
        }
    }
}
