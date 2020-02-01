using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InvoiceSystem.Business.Models;
using InvoiceSystem.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceSystem.ApiHost.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ParametersController : Controller
    {

        //private readonly IParameterService _parameterService;

        //public ParametersController(IParameterService parameterService)
        //{
        //    _parameterService = parameterService;
        //}

        //[HttpGet]
        //public async Task<ParameterModel> GetAsync() => await _parameterService.GetCompanyParameterAsync();

        //[HttpPut("{parameterId}")]
        //public void Put(int parameterId, [FromBody]ParameterModel model)
        //    => _parameterService.UpdateCompanyParameterAsync(parameterId, model);

        [HttpGet]
        public ParameterModel Get()
        {
            return new ParameterModel();
        }
    }
}
