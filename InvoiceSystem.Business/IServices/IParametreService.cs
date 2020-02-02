using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business
{
    public interface IParameterService
    {
        Task<ParameterModel> GetCompanyParameterAsync(int userId);

        Task UpdateCompanyParameterAsync(int id, ParameterModel model);
    }
}
