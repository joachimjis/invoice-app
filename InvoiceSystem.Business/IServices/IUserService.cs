using System;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
