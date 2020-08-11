using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Emart.AdminService.Models;
using Emart.AdminService.Repository;

namespace Emart.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repo;
        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("AddCategory")]
        public void Addcategory(Category obj)
        {
            _repo.AddCategory(obj);
        }
        [HttpGet]
        [Route("viewcategory")]
        public IActionResult view()
        {
            try
            {
                return Ok(_repo.viewcategory());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Route("AddSubCategory")]
        public void Addsubcategory(Subcategory obj)
        {
            _repo.AddSubcategory(obj);
        }
        [HttpGet]
        [Route("getcategory/{cid}")]
        public IActionResult getcategory(int cid)
        {
            return Ok(_repo.getbyid(cid));
        }
        [HttpGet]
        [Route("getsubcategory/{scid}")]
        public IActionResult getsubcategory(int scid)
        {

            return Ok(_repo.getby(scid));
        }
        [HttpGet]
        [Route("Getcategory")]
        public IActionResult Getcategory()
        {
            try
            {
                return Ok(_repo.Getcategory());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut]
        [Route("updatecategory")]
        public void updatecategory(Category obj)
        {

            _repo.updatecategory(obj);


        }
        [HttpPut]
        [Route("updatesubcategory")]
        public void updatesubcategory(Subcategory obj)
        {

            _repo.updatesubcategory(obj);


        }
        [HttpDelete]
        [Route("DeleteCategory/{cid}")]
        public void Deleteitem(int cid)
        {
            _repo.deleteitem(cid);
        }

        [HttpGet]
        [Route("Getsubcategory")]
        public IActionResult Getsubcategory( )
        {
            try
            {
                return Ok(_repo.Getsubcategory());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeletesubCategory/{scid}")]
        public void DeletesubCategory(int scid)
        {
            _repo.deleteItems(scid);
        }

    }

}