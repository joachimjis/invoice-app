using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.IServices;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<List<InvoiceModel>> GetInvoices(int userId)
            => await _invoiceRepository.GetInvoices(userId);

        public async Task<InvoiceModel> GetInvoiceInformation(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetInvoice(invoiceId);
            invoice.InvoiceLines = await _invoiceRepository.GetInvoiceLines(invoiceId);

            return invoice;
        }
    }
}
