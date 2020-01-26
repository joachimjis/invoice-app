using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceSystem.Infrastructure.Models
{
    public class Invoice
    {
        public Invoice()
        {
        }

        public int InvoiceId { get; set; }

        [Required]
        public string NumeroFacture { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }

        public DateTime DateEcheance { get; set; }

        [Required]
        public string Objet { get; set; }

        [Required]
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
