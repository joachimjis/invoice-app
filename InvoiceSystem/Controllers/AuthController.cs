using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InvoiceSystem.Auth;
using InvoiceSystem.Business;
using InvoiceSystem.Business.Enums;
using InvoiceSystem.Business.Models;
using InvoiceSystem.Business.Models.AuthModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceSystem.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public AuthController(IAuthenticationService _authenticationService)
        {
            authenticationService = _authenticationService;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            //var token = authenticationService.AuthenticateUser(user);

            //if (String.IsNullOrEmpty(token))
            //{
            //    return Unauthorized();
            //} else
            //{
            //    return Ok(new { Token = token });
            //}

            // to do authenticate


            var requestAt = DateTime.Now;
            var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;
            expiresIn = expiresIn.AddDays(2);
            var token = GenerateToken(user, expiresIn);

            return Ok(new RequestResult
            {
                State = RequestStateEnum.Success,
                Data = new
                {
                    requertAt = requestAt,
                    expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds,
                    tokeyType = TokenAuthOption.TokenType,
                    accessToken = token,
                    userId = 1,
                }
            });

            //    var claims = new[]
            //{
            //    new Claim(ClaimTypes.Name, user.UserName)
            //};

            //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

            //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(claims),
            //        Expires = DateTime.Now.AddDays(1),
            //        SigningCredentials = creds
            //    };

            //    var tokenHandler = new JwtSecurityTokenHandler();

            //    var token = tokenHandler.CreateToken(tokenDescriptor);

            //    //return Ok(new
            //    //{
            //    //    token = tokenHandler.WriteToken(token)
            //    //});

            //    var requestAt = DateTime.Now;

            //    return Ok(new RequestResult
            //    {
            //        State = RequestStateEnum.Success,
            //        Data = new
            //        {
            //            requertAt = requestAt,
            //            expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds,
            //            tokeyType = TokenAuthOption.TokenType,
            //            accessToken = token,
            //            userId = 1,
            //        }
            //    });

        }

        private string GenerateToken(LoginModel user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Expires = expires
            });
            return handler.WriteToken(securityToken);
        }

    }
}
