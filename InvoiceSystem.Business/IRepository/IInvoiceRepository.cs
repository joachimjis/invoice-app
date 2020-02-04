using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IRepository
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceModel>> GetInvoices(int userId);

        Task<InvoiceModel> GetInvoice(int invoiceId);

        Task<List<InvoiceLine>> GetInvoiceLines(int invoiceId);

        Task<decimal> GetTotalMontantTTC(int invoiceId);
    }
}
