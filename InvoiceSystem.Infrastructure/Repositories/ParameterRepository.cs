using System;
using System.Linq;
using System.Threading.Tasks;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.Models;
using InvoiceSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Infrastructure.Repositories
{
    public class ParameterRepository : IParameterRepository
    {
        private readonly ApplicationContext _context;

        public ParameterRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ParameterModel> GetParameterAsync()
        {
            var parameter = await _context.Parametres.FirstOrDefaultAsync();

            return new ParameterModel
            {
                ParametreId = parameter.ParametreId,
                CompanyName = parameter.NomSociete,
                Address = parameter.Adresse,
                PostalCode = parameter.CodePostal,
                Email = parameter.Email,
                PostalPlace = parameter.LieuPostal,
                Telephone = parameter.NumeroTelephone,
                Rib = parameter.Rib
            };
        }

        public async Task UpdateParameterAsync(int id, ParameterModel model)
        {
            var parameter = await _context.Parametres.FindAsync(id);
            parameter.Adresse = model.Address;
            parameter.CodePostal = model.PostalCode;
            parameter.Email = model.Email;
            parameter.LieuPostal = model.PostalPlace;
            parameter.NomSociete = model.CompanyName;
            parameter.NumeroTelephone = model.Telephone;
            parameter.Rib = model.Rib;

            _context.Parametres.Update(parameter);
            await _context.SaveChangesAsync();

        }
    }
}
