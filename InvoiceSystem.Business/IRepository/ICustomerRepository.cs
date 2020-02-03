using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetCustomersAsync(int userId);
    }
}
