using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerModel>> GetCustomersAsync(int userId)
        {
            return await _context.Clients
                .Where(customer => customer.UserId == userId)
                .Select(customer => new CustomerModel
                {
                    Id = customer.Id,
                    UserId = customer.UserId,
                    Name = customer.NomSociete,
                    Telephone = customer.NumeroTelephone,
                    Email = customer.Email,
                    ActivitySector = customer.SecteurActivite,
                    Rcs = customer.RCS,
                    Address = customer.AdressePhysique,
                    Suburb = customer.Commune,
                    Island = customer.Ile,
                    Comments = customer.Commentaire
                })
                .OrderBy(o => o.Name)
                .ToListAsync();
            }

        public async Task CreateCustomerAsync(CustomerModel customerModel)
        {
            await _context.Clients.AddAsync(new Models.Client
            {
                UserId = customerModel.UserId,
                NomSociete = customerModel.Name,
                Email = customerModel.Email,
                AdressePhysique = customerModel.Address,
                SecteurActivite = customerModel.ActivitySector,
                Commune = customerModel.Suburb,
                Ile = customerModel.Island,
                NumeroTelephone = customerModel.Telephone,
                RCS = customerModel.Rcs,
                Commentaire = customerModel.Rcs
            }); ;

            await _context.SaveChangesAsync();
        }
    }
}
