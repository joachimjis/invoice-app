using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InvoiceSystem.Business.Enums;

namespace InvoiceSystem.Infrastructure.Models
{
    public class Invoice
    {
        public Invoice()
        {
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string NumeroFacture { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public DateTime DateEcheance { get; set; }

        [Required]
        public string Objet { get; set; }

        [Required]
        public int ClientId { get; set; }

        public InvoiceStatusEnum InvoiceStatus { get; set; }

        public decimal MontantHT { get; set; }

        public decimal MontantTVA { get; set; }

        public decimal MontantTTC { get; set; }

        public Client Client { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<InvoiceLine> InvoiceLines { get; set; }
    }
}
