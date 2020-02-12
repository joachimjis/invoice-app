using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceSystem.Business.IServices;
using InvoiceSystem.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.ApiHost.Controllers
{
    [Route("api/[controller]")]
    public class InvoicesController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<List<InvoiceModel>> GetInvoices([FromQuery] int userId)
            => await _invoiceService.GetInvoices(userId);

        [HttpGet("{id}")]
        public async Task<InvoiceModel> Get(int id)
            => await _invoiceService.GetInvoiceInformation(id);

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]InvoiceModel invoiceModel)
        {
            await _invoiceService.CreateInvoice(invoiceModel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
