using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceSystem.Infrastructure.Models
{
    public class Parametre
    {
        public Parametre()
        {
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string NomSociete { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public string CodePostal { get; set; }

        [Required]
        public string LieuPostal { get; set; }

        [Required]
        public int NumeroTelephone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Rib { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
