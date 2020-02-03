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

        public async Task<CustomerModel> GetCustomerAsync(int customerId)
        {
            var customer = await _context.Clients.FirstOrDefaultAsync(d => d.Id == customerId);

            if (customer == null)
            {
                return null;
            }

            return new CustomerModel
            {
                Id = customer.Id,
                UserId = customer.UserId,
                Telephone = customer.NumeroTelephone,
                Email = customer.Email,
                Name = customer.NomSociete,
                Address = customer.AdressePhysique,
                ActivitySector = customer.SecteurActivite,
                Suburb = customer.Commune,
                Island = customer.Ile,
                Rcs = customer.RCS,
                Comments = customer.Commentaire
            };
        }

        public async Task UpdateCustomerAsync(int id, CustomerModel customerModel)
        {
            var customer = await _context.Clients.FindAsync(id);
            customer.NomSociete = customerModel.Name;
            customer.NumeroTelephone = customerModel.Telephone;
            customer.Email = customerModel.Email;
            customer.SecteurActivite = customerModel.ActivitySector;
            customer.RCS = customerModel.Rcs;
            customer.AdressePhysique = customerModel.Address;
            customer.Commune = customerModel.Suburb;
            customer.Ile = customerModel.Island;
            customer.Commentaire = customerModel.Comments;

            _context.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
