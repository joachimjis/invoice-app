using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceSystem.Infrastructure.Models
{
    public class Client
    {
        public int ClientId { get; set; }

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

        [Required]
        public int UserId { get; set; }

        public int User { get; set; }
    }
}
