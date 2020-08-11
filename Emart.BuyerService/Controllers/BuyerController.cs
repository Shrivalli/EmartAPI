using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Emart.BuyerService.Models;
using Emart.BuyerService.Repository;

namespace Emart.BuyerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IbuyerRepository _repo;
        public BuyerController(IbuyerRepository repo)
        {
            _repo = repo;
        }


        [HttpPost]
        [Route("Additem")]
        public void buyitem(PurchaseHistory obj)
        {
            _repo.buyitem(obj);
        }

        [HttpPut]
        [Route("editbuyerprofile")]
        public void Editprofile(Buyer obj)
        {
            _repo.editbuyerprofile(obj);

        }
        [HttpGet]
        [Route("getprofile/{bid}")]
        public IActionResult getprofile(int bid)
        {
            try
            {
                return Ok(_repo.getprofile(bid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("search/{itemname}")]
        public IActionResult searchitem(string itemname)
        {
            try
            {
                return Ok(_repo.searchitems(itemname));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("Transactionhistory/{bid}")]
        public IActionResult transactionhistory(int bid)
        {
            try
            {
                return Ok(_repo.transactionshistory(bid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetCategory")]
        public IActionResult GetCategory()
        {
            try
            {
                return Ok(_repo.GetCategory());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }
        [HttpGet]
        [Route("GetSubCategory/{cid}")]
        public IActionResult Getsubcategory(int cid)
        {
            try
            {
                return Ok(_repo.GetSubcategories(cid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("addtocart")]
        public void Addtocart(Cart obj)
        {
            try
            {
                _repo.Addtocart(obj);
            }
            catch (Exception e)
            {
                NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route("GetCart/{bid}")]
        public IActionResult GetCart(int bid)
        {
            try
            {
                return Ok(_repo.GetCart(bid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }
        [HttpDelete]
        [Route("deletefromcart/{cartid}")]
        public void Delete(int cartid)
        {
            _repo.deletefromcart(cartid);
        }
        
    }
}