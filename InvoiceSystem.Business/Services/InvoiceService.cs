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
        private readonly ICustomerRepository _customerRepository;

        public InvoiceService(
            IInvoiceRepository invoiceRepository,
            ICustomerRepository customerRepository
            )
        {
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;
        }

        public async Task<List<InvoiceModel>> GetInvoices(int userId)
        {
            var invoices = await _invoiceRepository.GetInvoices(userId);
            foreach (var invoice in invoices)
            {
                var customer = await _customerRepository.GetCustomerAsync(invoice.CustomerId);
                invoice.CustomerName = customer.Name;
                invoice.MontantTTC = await _invoiceRepository.GetTotalMontantTTC(invoice.InvoiceId);
            }
            return invoices;
        }

        public async Task<InvoiceModel> GetInvoiceInformation(int invoiceId)
        {
            var invoice = await _invoiceRepository.GetInvoice(invoiceId);
            invoice.InvoiceLines = await _invoiceRepository.GetInvoiceLines(invoiceId);

            return invoice;
        }

        public async Task<string> GetNextInvoiceNumber()
        {
            var lastInvoiceNumber = await _invoiceRepository.GetLastInvoiceNumber();

            if (string.IsNullOrEmpty(lastInvoiceNumber))
            {
                return DateTime.Now.Year + "001";
            }
            else
            {
                int year = Int32.Parse(lastInvoiceNumber.Substring(0, 4));
                int nextNumber = Int32.Parse(lastInvoiceNumber.Substring(4)) + 1;

                if (year < DateTime.Now.Year)
                {
                    return DateTime.Now.Year + "001";
                }
                else
                {
                    return year + nextNumber.ToString().PadLeft(3, '0');
                }
            }
        }

        public async Task CreateInvoice(InvoiceModel invoiceModel)
        {
            invoiceModel.InvoiceNumber = await GetNextInvoiceNumber();
            await _invoiceRepository.CreateInvoice(invoiceModel);
        }
    }
}
