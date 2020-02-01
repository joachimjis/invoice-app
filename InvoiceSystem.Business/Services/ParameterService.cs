using System;
using System.Threading.Tasks;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business
{
    public class ParameterService : IParameterService
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterService(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task<ParameterModel> GetCompanyParameterAsync() =>
            await _parameterRepository.GetParameterAsync();

        public async Task UpdateCompanyParameterAsync(int id, ParameterModel model) =>
            await _parameterRepository.UpdateParameterAsync(id, model);
    }
}
