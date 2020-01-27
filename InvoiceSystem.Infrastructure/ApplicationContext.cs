using System;
using InvoiceSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Parametre> Parametres { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }


    }
}
