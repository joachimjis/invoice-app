using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Client Client { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
