using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emart.AdminService.Models;
namespace Emart.AdminService.Repository
{
    public interface IAdminRepository
    {
        List<Category> viewcategory();
        void AddCategory(Category obj);
        void AddSubcategory(Subcategory obj);
        Category getbyid(int cid);
        Subcategory getby(int scid);
        List<Category> Getcategory();
        void updatecategory(Category obj);
        void updatesubcategory(Subcategory obj);
        void deleteitem(int cid);
        List<Subcategory> Getsubcategory();

        void deleteItems(int scid);
    }
}
