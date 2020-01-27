using System;
namespace InvoiceSystem.Business.Models
{
    public class ParameterModel
    {
        public ParameterModel()
        {
        }

        public int ParametreId { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string PostalPlace { get; set; }

        public int Telephone { get; set; }

        public string Email { get; set; }

        public string Rib { get; set; }
    }
}
