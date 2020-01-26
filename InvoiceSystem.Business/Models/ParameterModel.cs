using System;
namespace InvoiceSystem.Business.Models
{
    public class ParameterModel
    {
        public ParameterModel()
        {
        }

        public int ParametreId { get; set; }

        public string NomSociete { get; set; }

        public string Adresse { get; set; }

        public string CodePostal { get; set; }

        public string LieuPostal { get; set; }

        public int NumeroTelephone { get; set; }

        public string Email { get; set; }

        public string Rib { get; set; }
    }
}
