using System;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IRepository
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserAsync(string userName, string password);
    }
}
