using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Emart.SellerService.Repository;
using Emart.SellerService.Models;

namespace Emart.SellerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IsellerRepository _repo;
        public SellerController(IsellerRepository repo)
        {
            _repo = repo;
        }

        [HttpPut]
        [Route("editsellerprofile")]
        public IActionResult editprofile(Seller obj)
        {
            try
            {
                _repo.EditProfile(obj);
                return Ok();
            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("getprofile/{sid}")]
        public IActionResult getprofile(int sid)
        {
            try
            {
                return Ok(_repo.getprofile(sid));
            }
            catch (Exception e)
            {
                return Ok(e.InnerException.Message);
            }
        }
    }
}