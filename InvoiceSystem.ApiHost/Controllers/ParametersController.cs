using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InvoiceSystem.Business.Models;
using InvoiceSystem.Business;

namespace InvoiceSystem.ApiHost.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ParametersController : Controller
    {

        private readonly IParameterService _parameterService;

        public ParametersController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        [HttpGet]
        public async Task<ParameterModel> GetAsync([FromQuery] int userId) => await _parameterService.GetCompanyParameterAsync(userId);

        [HttpPut]
        public void Put(int parameterId, [FromBody]ParameterModel model)
            => _parameterService.UpdateCompanyParameter(model);
    }
}
