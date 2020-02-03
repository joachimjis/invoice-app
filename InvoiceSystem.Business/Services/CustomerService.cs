using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.IServices;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerModel>> GetCustomersAsync(int userId)
         => await _customerRepository.GetCustomersAsync(userId);
    }
}
