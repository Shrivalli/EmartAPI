using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Emart.Userservice.Repository;
using Emart.Userservice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Emart.Userservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repo;
        private readonly IConfiguration configuration; 
        public AccountController(IAccountRepository repo,IConfiguration configuration)
        {
            this.configuration = configuration;
            _repo = repo;
        }
        [HttpGet]
        [Route("BLogin/{uname}/{pwd}")]
        public IActionResult BLogin(string uname, string pwd)
        {
            Token token = null;
            try
            {
                Buyer buyer = _repo.BuyerLogin(uname, pwd);
                if (buyer != null)
                {
                    token = new Token() { bid = buyer.Bid, token = GenerateJwtToken(uname), message = "success" };

                }
                else
                {
                    token = new Token() { token = null, message = "unsuccess" };
                }
                return Ok(token);
            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }


        }
        [HttpGet]
        [Route("SLogin/{uname}/{pwd}")]
        public IActionResult SLogin(string uname, string pwd)
        {
            Token token = null;
            try
            {
                Seller seller = _repo.SellerLogin(uname, pwd);
                if (seller != null)
                {
                    token = new Token() { sid = seller.Sid, token = GenerateJwtToken(uname), message = "success" };

                }
                else
                {
                    token = new Token() { token = null, message = "unsuccess" };
                }
                return Ok(token);
            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }
        }
        [HttpPost]
        [Route("SRegister")]
        public IActionResult SRegister(Seller obj)
        {
            try
            {
                _repo.SellerRegister(obj);
                return Ok();
            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }
        }
        [HttpPost]
        [Route("BRegister")]
        public IActionResult BRegister(Buyer obj)
        {
            try
            {
                _repo.BuyerRegister(obj);
                return Ok();
            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }
        }

        private string GenerateJwtToken(string uname)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, uname),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, uname),
                new Claim(ClaimTypes.Role,uname)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // recommended is 5 min
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: credentials
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        

          
    }


}
}