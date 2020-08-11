using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emart.BuyerService.Models;
namespace Emart.BuyerService.Repository
{
    public interface IbuyerRepository
    {
        List<Items> searchitems(string item_name);
        void buyitem(PurchaseHistory obj);
        void editbuyerprofile(Buyer obj);
        Buyer getprofile(int bid);
        List<PurchaseHistory> transactionshistory(int bid);
        List<Category> GetCategory();
        List<Subcategory> GetSubcategories(int category_id);
        void Addtocart(Cart obj);
        void deletefromcart(int cartid);
        List<Cart> GetCart(int bid);
    }
}
