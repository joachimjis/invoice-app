using System;
using System.Threading.Tasks;
using InvoiceSystem.Business.IRepository;
using InvoiceSystem.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetUserAsync(string userName, string password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(f =>
                f.Username == userName && f.Password == password);

                if (user == null)
                {
                    return null;
                }

                return new UserModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Password = user.Password,
                    Token = user.Token
                };
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
