using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emart.SellerService.Models;
namespace Emart.SellerService.Repository
{
   public  interface IItemRepository
    {
        List<Items> GetAllItems();
        List<Items> viewitems(int iid);
        void deleteitem(int iid);
        void updateitem(Items obj);
        Items Getitem(int iid);
        void Additems(Items obj);

    }
}
