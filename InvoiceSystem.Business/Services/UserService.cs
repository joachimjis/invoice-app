using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using InvoiceSystem.Business.Helpers;
using InvoiceSystem.Business.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InvoiceSystem.Business.Services
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "johndoe", Password = "def@123" }
        };

        private readonly AppSettings _appSettings;

        private IConfiguration _config;

        public UserService(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _appSettings = appSettings.Value;
            _config = configuration;
        }

        public User Authenticate(string username, string password)
        {
                var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

                // return null if user not found
                if (user == null)
                    return null;

                // authentication successful so generate jwt token
                //var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_config["Jwt:Issuer"]);
                //var tokenDescriptor = new SecurityTokenDescriptor
                //{
                //    Subject = new ClaimsIdentity(new Claim[]
                //    {
                //        new Claim(ClaimTypes.Name, user.Id.ToString())
                //    }),
                //    Expires = DateTime.UtcNow.AddDays(7),
                //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                //};
                //var token = tokenHandler.CreateToken(tokenDescriptor);
                //user.Token = tokenHandler.WriteToken(token);

                var handler = new JwtSecurityTokenHandler();

                var keyByteArray = Encoding.ASCII.GetBytes(_config["Jwt:Issuer"]);
                var signingKey = new SymmetricSecurityKey(keyByteArray);
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = "Issuer",
                    Audience = "Audience",
                    SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                    Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                        }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    NotBefore = DateTime.Now
                });

                user.Token = handler.WriteToken(securityToken);


                return user.WithoutPassword();
        }
    }
}
