using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emart.AdminService.Models;

namespace Emart.AdminService.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EmartDBContext _context;
        public AdminRepository(EmartDBContext context)
        {
            _context = context;
        }
        public void AddCategory(Category obj)
        {
            _context.Category.Add(obj);
            _context.SaveChanges();

        }

        public void AddSubcategory(Subcategory obj)
        {
            _context.Subcategory.Add(obj);
            _context.SaveChanges();

        }

        public Subcategory getby(int scid)
        {
            return _context.Subcategory.Find(scid);
        }

        public Category getbyid(int cid)
        {
            return _context.Category.Find(cid);
        }

        List<Category> viewcategory()
        {
            return _context.Category.ToList();
        }
        public List<Category> Getcategory()
        {
            return _context.Category.ToList();
        }
        public void deleteitem(int cid)
        {
            Category i = _context.Category.Find(cid);
            _context.Category.Remove(i);
            _context.SaveChanges();
        }


        public List<Subcategory> Getsubcategory()
        {
            return _context.Subcategory.ToList();
        }
        public void deleteItems(int scid)
        {
            Subcategory i = _context.Subcategory.Find(scid);
            _context.Subcategory.Remove(i);
            _context.SaveChanges();
        }

        public void updatecategory(Category obj)
        {
           
            _context.Category.Update(obj);
            _context.SaveChanges();
        }
        public void updatesubcategory(Subcategory obj)
        {
            
            _context.Subcategory.Update(obj);
            _context.SaveChanges();
        }

        List<Category> IAdminRepository.viewcategory()
        {
            throw new NotImplementedException();
        }
    }
}