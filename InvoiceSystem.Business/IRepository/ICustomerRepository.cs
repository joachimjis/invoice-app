using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetCustomersAsync(int userId);

        Task<CustomerModel> GetCustomerAsync(int customerId);

        Task CreateCustomerAsync(CustomerModel customerModel);

        Task UpdateCustomerAsync(int id, CustomerModel customerModel);

        Task<int> CountCustomerInvoices(int id);

        void DeleteCustomer(int id);
    }
}
