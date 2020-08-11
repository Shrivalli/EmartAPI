using System;
using System.Collections.Generic;
using System.Text;
using Emart.BuyerService.Controllers;
using Emart.BuyerService.Models;
using Emart.BuyerService.Repository;
using NUnit.Framework;

namespace Emart.Test
{
    [TestFixture]
    public class TestBuyerRepository
    {
        BuyerRepository _repo;
        [SetUp]
        public void setup()
        {
            _repo = new BuyerRepository(new EmartDBContext());
        }
        [Test]
        [Description("GetCart")]
        public void TestGetCart()
        {
            var result = _repo.GetCart(2);
            Assert.NotNull(result);
            Assert.Greater(result.Count, 1);
        }
        //[Test]
        //public void Testdeletefromcart()
        //{
        //    _repo.deletefromcart(620);
        //    var result = _repo.GetCart(620);
        //    Assert.Null(result);
        //}
        [Test]
        [Description("get buyer profile")]
        public void TestGetprofile()
        {
            var x = _repo.getprofile(1);
            Assert.IsNotNull(x);
        }
        [Test]
        [Description(" buyer edit  profile")]
        public void TestEditprofile()
        {
            Buyer x = _repo.getprofile(1);
            x.Bemail = "buyer305@gmail.com";
            _repo.editbuyerprofile(x);
            Buyer y = _repo.getprofile(1);
            Assert.AreSame(x, y);

        }
        [Test]
        [Description("get transaction history ")]
        public void TestTransaction()
        {
            var result = _repo.transactionshistory(1);
            Assert.NotNull(result);
        }
        [Test]
        [Description("Buy product")]
        public void TestBuyproduct()
        {
            _repo.buyitem(new PurchaseHistory()
            {
                  Bid=1,
                   DateTime=System.DateTime.Now,
                    TransactionType="credit",
                      NoOfItems=2,
                         Tid=92,
                          Iid=835,
                            Sid=1,
                             Remarks="gud",
                    
            });
            var x = _repo.transactionshistory(2);
            Assert.IsNotNull(x);

        }
        [Test]
        [Description("test add to cart")]
        public void TestAddCart()
        {
            _repo.Addtocart(new Cart()
            {
                Cartid = 86,
                Bid = 1,
                Cid = 1,
                Description = "notbad",
                Iid = 55,
                Imagepath = "46.jpg",
                ItemName = "teddypillows",
                Price = 785,
                Sid = 1,
                 StockNo = 1,
               Scid = 1,

            });
            var x = _repo.GetCart(2);
            Assert.IsNotNull(x);


        }
        [Test]
        [Description("Get Category")]
        public void TestGetCategory()
        {
            var x = _repo.GetCategory();
            Assert.NotNull(x);
            Assert.Greater(x.Count, 0);
        }
        [Test]
        [Description("Get subCategory")]
        public void TestGetsubCategory()
        {
            var x = _repo.GetSubcategories(4);
            Assert.NotNull(x);
            //   Assert.Greater(x.Count, 0);
        }
        [Test]
        [Description("Get item  search by name")]
        public void TestsearchIteam()
        {
            var x = _repo.searchitems("T-shirt");
            Assert.NotNull(x);
            //   Assert.Greater(x.Count, 0);
        }
        [Test]
        [Description("Delete from cart")]
        public void TestDeleteFromCart()
        {

            _repo.deletefromcart(456);
            //var x = _repo.GetCart(2);
            //Assert.Null(x);
           // Assert.Greater(x.Count, 0);
        }


    }


}


