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

        public async Task<ParameterModel> GetCompanyParameterAsync(int userId) =>
            await _parameterRepository.GetParameterAsync(userId);

        public void UpdateCompanyParameter(ParameterModel model) =>
             _parameterRepository.UpdateParameter(model);
    }
}
