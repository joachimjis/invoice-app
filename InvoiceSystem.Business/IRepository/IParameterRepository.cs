using System;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IRepository
{
    public interface IParameterRepository
    {
        Task<ParameterModel> GetParameterAsync();

        Task InsertParameterAsync(ParameterModel model);

        Task UpdateParameterAsync(ParameterModel model);
    }
}
