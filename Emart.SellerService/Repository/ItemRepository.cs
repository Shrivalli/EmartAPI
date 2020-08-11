using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emart.SellerService.Models;

namespace Emart.SellerService.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly EmartDBContext _context;
        public ItemRepository(EmartDBContext context)
        {
            _context = context;
        }
        public void Additems(Items obj)
        {
            _context.Items.Add(obj);
            _context.SaveChanges();
        }
        public void deleteitem(int iid)
        {
            Items i = _context.Items.Find(iid);
            _context.Items.Remove(i);
            _context.SaveChanges();
        }
        public void updateitem(Items obj)
        {
            //Items i = new Items();
            //i.Price = obj.Price;
            //i.ItemName = obj.ItemName;
            //i.StockNo = obj.StockNo;
            //i.Iid = obj.Iid;
            _context.Items.Update(obj);
            _context.SaveChanges();
        }

        public Items Getitem(int iid)
        {

            return _context.Items.Find(iid);

        }

        public List<Items> viewitems(int sid)
        {
            return _context.Items.Where(e => e.Sid == sid).ToList();



        }

        public List<Items> GetAllItems()
        {
            return _context.Items.ToList();
        }
    }
}