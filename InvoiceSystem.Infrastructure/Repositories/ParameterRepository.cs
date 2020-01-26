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
                NomSociete = parameter.NomSociete,
                Adresse = parameter.Adresse,
                CodePostal = parameter.CodePostal,
                Email = parameter.Email,
                LieuPostal = parameter.LieuPostal,
                NumeroTelephone = parameter.NumeroTelephone,
                Rib = parameter.Rib
            };
        }

        public async Task InsertParameterAsync(ParameterModel model)
        {
            await _context.Parametres.AddAsync(new Parametre
            {
                Adresse = model.Adresse,
                CodePostal = model.CodePostal,
                Email = model.Email,
                LieuPostal = model.LieuPostal,
                NomSociete = model.NomSociete,
                NumeroTelephone = model.NumeroTelephone,
                Rib = model.Rib
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateParameterAsync(ParameterModel model)
        {
            var parameter = await _context.Parametres.FirstOrDefaultAsync();
            parameter.Adresse = model.Adresse;
            parameter.CodePostal = model.CodePostal;
            parameter.Email = model.Email;
            parameter.LieuPostal = model.LieuPostal;
            parameter.NomSociete = model.NomSociete;
            parameter.NumeroTelephone = model.NumeroTelephone;
            parameter.Rib = model.Rib;

            _context.Parametres.Update(parameter);
            await _context.SaveChangesAsync();

        }
    }
}
