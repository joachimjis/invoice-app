using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IServices
{
    public interface IInvoiceService
    {
        Task<List<InvoiceModel>> GetInvoices(int userId);
        Task<InvoiceModel> GetInvoiceInformation(int invoiceId);
    }
}
