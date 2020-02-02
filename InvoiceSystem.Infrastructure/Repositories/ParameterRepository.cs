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

        public async Task<ParameterModel> GetParameterAsync(int userId)
        {
            var parameter = await _context.Parametres.FirstOrDefaultAsync(f => f.UserId == userId);

            if (parameter == null)
            {
                return new ParameterModel();
            }

            return new ParameterModel
            {
                ParameterId = parameter.Id,
                CompanyName = parameter.NomSociete,
                Address = parameter.Adresse,
                PostalCode = parameter.CodePostal,
                Email = parameter.Email,
                PostalPlace = parameter.LieuPostal,
                Telephone = parameter.NumeroTelephone,
                Rib = parameter.Rib
            };
        }

        public void UpdateParameter(ParameterModel model)
        {
            var parameter = _context.Parametres.Find(model.ParameterId);
            parameter.Adresse = model.Address;
            parameter.CodePostal = model.PostalCode;
            parameter.Email = model.Email;
            parameter.LieuPostal = model.PostalPlace;
            parameter.NomSociete = model.CompanyName;
            parameter.NumeroTelephone = model.Telephone;
            parameter.Rib = model.Rib;

            _context.Parametres.Update(parameter);
            _context.SaveChanges();

        }
    }
}
