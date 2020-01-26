using System;
namespace InvoiceSystem.Business
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        string AuthenticateUser(LoginModel loginModel);


    }
}
