using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceSystem.Infrastructure.Models
{
    public class InvoiceLine
    {
        public InvoiceLine()
        {
        }

        public int Id { get; set; }

        public int InvoiceId { get; set; }

        [Required]
        public string Libelle { get; set; }

        [Required]
        public decimal Quantite { get; set; }

        [Required]
        public decimal MontantHT { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
    }
}
