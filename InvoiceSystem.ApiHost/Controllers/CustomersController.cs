using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceSystem.Business.IServices;
using InvoiceSystem.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.ApiHost.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<List<CustomerModel>> GetCustomers([FromQuery] int userId)
            => await _customerService.GetCustomersAsync(userId);

        [HttpGet("{id}")]
        public async Task<CustomerModel> Get(int id)
        {
            return await _customerService.GetCustomerAsync(id);
        }

        [HttpPost]
        public async Task PostAsync([FromBody] CustomerModel customerModel)
        {
            if (customerModel.UserId == 0)
            {
                 BadRequest();
            }

            await _customerService.CreateCustomerAsync(customerModel);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]CustomerModel customerModel)
            => await _customerService.UpdateCustomerAsync(id, customerModel);

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
