using System;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IRepository
{
    public interface IParameterRepository
    {
        Task<ParameterModel> GetParameterAsync(int userId);

        Task UpdateParameterAsync(int id, ParameterModel model);
    }
}
