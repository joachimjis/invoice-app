using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationContext _context;

        public InvoiceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<InvoiceModel>> GetInvoices(int userId)
        {
            return await _context.Invoices.Where(w => w.UserId == userId)
                .Select(inv => new InvoiceModel
            {
                InvoiceNumber = inv.NumeroFacture,
                DateCreation = inv.DateCreation,
                DateEcheance = inv.DateEcheance,
                CustomerId = inv.ClientId,
                InvoiceId = inv.Id,
                Object = inv.Objet,
                UserId = inv.UserId,
                InvoiceStatus = inv.InvoiceStatus
            }).OrderBy(o => o.DateCreation).ToListAsync();
        }

        public async Task<List<InvoiceLine>> GetInvoiceLines(int invoiceId)
        {
            return await _context.InvoiceLines.Where(w => w.InvoiceId == invoiceId)
                .Select(line => new InvoiceLine
                {
                    Label = line.Libelle,
                    Quantity = line.Quantite,
                    MontantHT = line.MontantHT,
                    MontantTVA = line.MontantTVA,
                    MontantTTC = line.MontantTTC,
                    InvoiceId = line.InvoiceId,
                    InvoiceLineId = line.Id
                }).ToListAsync();
        }

        public async Task<InvoiceModel> GetInvoice(int invoiceId)
        {
            return await _context.Invoices.Where(w => w.Id == invoiceId).Select(inv => new InvoiceModel
            {
                InvoiceNumber = inv.NumeroFacture,
                DateCreation = inv.DateCreation,
                DateEcheance = inv.DateEcheance,
                CustomerId = inv.ClientId,
                InvoiceId = inv.Id,
                Object = inv.Objet,
                UserId = inv.UserId,
                InvoiceStatus = inv.InvoiceStatus
            }).FirstOrDefaultAsync();
        }
    }
}
