using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IServices
{
    public interface IUserService
    {
        Task<UserModel> AuthenticateAsync(string username, string password);
    }
}
