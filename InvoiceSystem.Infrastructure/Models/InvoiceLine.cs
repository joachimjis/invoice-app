using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceSystem.Infrastructure.Models
{
    public class InvoiceLine
    {
        public InvoiceLine()
        {
        }

        public int InvoiceLineId { get; set; }

        [Required]
        public string Libelle { get; set; }

        [Required]
        public decimal Quantite { get; set; }

        [Required]
        public decimal MontantHT { get; set; }

        [Required]
        public decimal MontantTVA { get; set; }

        [Required]
        public decimal MontantTTC { get; set; }

        [Required]
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }
    }
}
