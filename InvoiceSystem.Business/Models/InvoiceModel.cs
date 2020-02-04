using System;
using System.Collections.Generic;
using InvoiceSystem.Business.Enums;

namespace InvoiceSystem.Business.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateEcheance { get; set; }
        public InvoiceStatusEnum InvoiceStatus { get; set; }
        public string Object { get; set; }
        public int CustomerId { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; }
    }

    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public string Label { get; set; }
        public decimal Quantity { get; set; }
        public decimal MontantHT { get; set; }
        public decimal MontantTVA { get; set; }
        public decimal MontantTTC { get; set; }
    }
}
