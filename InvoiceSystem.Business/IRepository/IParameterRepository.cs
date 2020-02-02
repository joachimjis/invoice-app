using System;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IRepository
{
    public interface IParameterRepository
    {
        Task<ParameterModel> GetParameterAsync(int userId);
        void UpdateParameter(ParameterModel model);
    }
}
