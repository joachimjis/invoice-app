using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceSystem.Infrastructure.Models
{
    public class Client
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string NomSociete { get; set; }

        public int NumeroTelephone { get; set; }

        [Required]
        public string Email { get; set; }

        public string SecteurActivite { get; set; }

        [Required]
        public string RCS { get; set; }

        [Required]
        public string AdressePhysique { get; set; }

        [Required]
        public string Commune { get; set; }

        public string Ile { get; set; }

        public string Commentaire { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
