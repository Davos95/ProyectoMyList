using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiMyList.Models;
using ApiMyList.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ApiMyList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IRepositoryUser repo;
        IConfiguration configuration;
        public AuthController(IRepositoryUser repo, IConfiguration configuration)
        {
            this.repo = repo;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(USER user)
        {
            USER userLogin = this.repo.ExisteUsuario(user.Nick, user.Password);
            if (userLogin != null)
            {
                Claim[] claims = new[]
                {
                    new Claim("UserData", JsonConvert.SerializeObject(userLogin))
                };

                JwtSecurityToken token = new JwtSecurityToken
                (
                    issuer: configuration["ApiAuth:Issuer"],
                    audience: configuration["ApiAuth:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApiAuth:SecretKey"])), SecurityAlgorithms.HmacSha256)
                );

                return Ok(
                    new
                    {
                        response = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                );
            }
            else
            {
                return Unauthorized();
            }
        }


    }
}