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
        {
            var customers = await _customerRepository.GetCustomersAsync(userId);
            foreach (var customer in customers)
            {
                customer.CanDelete = await CheckIfCanDeleteCustomerAsync(customer.Id);
            }

            return customers;
        }

        public async Task<CustomerModel> GetCustomerAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerAsync(customerId);
            customer.CanDelete = await CheckIfCanDeleteCustomerAsync(customerId);
            return customer;
        }

        public async Task CreateCustomerAsync(CustomerModel customerModel)
            => await _customerRepository.CreateCustomerAsync(customerModel);

        public async Task UpdateCustomerAsync(int id, CustomerModel customerModel)
            => await _customerRepository.UpdateCustomerAsync(id, customerModel);

        public async Task<bool> CheckIfCanDeleteCustomerAsync(int id)
        {
            int numberInvoices = await _customerRepository.CountCustomerInvoices(id);
            if (numberInvoices == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            if (await CheckIfCanDeleteCustomerAsync(id))
            {
                _customerRepository.DeleteCustomer(id);
                return true;
            }
            return false;
        }
    }
}
