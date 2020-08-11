using System;
using System.Collections.Generic;
using System.Text;
using Emart.SellerService.Repository;
using Emart.SellerService.Models;
using Emart.SellerService.Controllers;
using NUnit.Framework;

namespace Emart.Test
{
    [TestFixture]
   public  class TestItemRepository
    {
   
        ItemRepository _repo;
        [SetUp]
        public void setup()
        {
            _repo = new ItemRepository(new EmartDBContext());
        }
        [Test]
        [Description("GetAllItems")]
        public void TestGetAllItems()
        {
            var result = _repo.GetAllItems();
            Assert.NotNull(result);
            Assert.Greater(result.Count, 3);
        }
        [Test]
        public void TestGetitem()
        {
            var result = _repo.Getitem(506);
            Assert.IsNotNull(result);
        }
        [Test]

        public void Testviewitems()
        {
            var result = _repo.viewitems(1);
            Assert.NotNull(result);
            Assert.Greater(result.Count, 1);

        }
        [Test]
        public void Testdeleteitem()
        {
            _repo.deleteitem(986);
            var result = _repo.Getitem(986);
            Assert.Null(result);
                }
        [Test]
        public void TestAdditems()
        {
            _repo.Additems(new Items()
            {
                Cid = 1,
                Scid = 1,
                Iid = 85,
                ItemName = "themeteddy",
                Price = 900,
                Remarks = "good",
                StockNo = 3,
                Description = "teddy",
                Imagepath = "6.jpg",
                 Sid=1
            });
            var result = _repo.Getitem(85);
            Assert.NotNull(result);

        }
        [Test]
        public  void Testupdateitem()
        {
            Items item = _repo.Getitem(393);
            item.Price = 707;
            _repo.updateitem(item);
            Items item1 = _repo.Getitem(393);
            Assert.AreSame(item, item1);
        }
    }
}
