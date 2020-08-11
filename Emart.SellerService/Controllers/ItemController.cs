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
    public class ItemController : ControllerBase
    {

        private readonly IItemRepository _repo;
        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("Additem")]
        public IActionResult Additem(Items obj)
        {
            try
            {
                _repo.Additems(obj);
                return Ok("item added");
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("ViewItems/{sid}")]
        public IActionResult viewitems(int sid)
        {
            try
            {
                return Ok(_repo.viewitems(sid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("Deleteitem/{iid}")]
        public void Deleteitem(int iid)
        { 
            _repo.deleteitem(iid);
        }
        [HttpPut]
        [Route("updateitem")]
        public void updateitem(Items obj)
        {

            _repo.updateitem(obj);


        }
        [HttpGet]
        [Route("GetItems")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repo.GetAllItems());
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpGet]
        [Route("getitem/{iid}")]
        public IActionResult getitem(int iid)
        {
            try
            {
                return Ok(_repo.Getitem(iid));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);

            }
        }

    }
}