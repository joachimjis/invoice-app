using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business
{
    public interface IParameterService
    {
        Task<ParameterModel> GetCompanyParameterAsync();

        Task UpdateCompanyParameterAsync(ParameterModel model);
    }
}
