using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IServices
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetCustomersAsync(int userId);

        Task<CustomerModel> GetCustomerAsync(int customerId);

        Task CreateCustomerAsync(CustomerModel customerModel);

        Task UpdateCustomerAsync(int id, CustomerModel customerModel);

        Task<bool> CheckIfCanDeleteCustomerAsync(int id);

        Task<bool> DeleteCustomerAsync(int id);
    }
}
