using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceSystem.Business;
using InvoiceSystem.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceSystem.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class ParameterController : Controller
    {
        private readonly IParameterService _parameterService;

        public ParameterController(IParameterService parameterService)
        {
            _parameterService = parameterService;
        }

        [HttpGet]
        public async Task<ParameterModel> GetAsync() => await _parameterService.GetCompanyParameterAsync();

        [HttpPut("{parameterId}")]
        public void Put(int parameterId, [FromBody]ParameterModel model)
            => _parameterService.UpdateCompanyParameterAsync(parameterId, model);
    }
}
