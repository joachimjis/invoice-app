using System;
using System.Collections.Generic;
using InvoiceSystem.Business.Models;

namespace InvoiceSystem.Business.IServices
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
