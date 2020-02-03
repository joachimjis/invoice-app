using System;
namespace InvoiceSystem.Business.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string ActivitySector { get; set; }
        public string Rcs { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string Island { get; set; }
        public string Comments { get; set; }
    }
}
