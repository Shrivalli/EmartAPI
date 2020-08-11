using System;
using System.Collections.Generic;
using System.Text;
using Emart.Userservice.Controllers;
using Emart.Userservice.Models;
using Emart.Userservice.Repository;
using NUnit.Framework;
namespace Emart.Test
{

    [TestFixture]
     public class TestUserRepository
    {
        AccountRepository _repo;
        [SetUp]
        public void setup()
        {
            _repo = new AccountRepository(new EmartDBContext());

        }
        [Test]
        [Description("get buyer Login")]
        public void TestBuyerLogin()
        {
            Buyer b = _repo.BuyerLogin("buyer", "buyer");
            Assert.IsNotNull(b);
        }
        [Test]
        [Description("test seller Login")]
        public void TestSellerLogin()
        {
            Seller s = _repo.SellerLogin("seller", "seller");
            Assert.IsNotNull(s);
        }
        [Test]
        [Description("Test buyer registraction")]
        public void TestBuyerRegistration()
        {
            _repo.BuyerRegister(new Buyer()
            {
                 Bid=46,
                  Bname="priya",
                   Bemail="priya@gmail.com",
                    Bpwd="ASDFGHJ@",
                     Bno="963582147",
                      Bdate=System.DateTime.Now,
                //Bid = 55,
                //Bmail = "buyer99@gmail.com",
                //Bmobile = "9999999999",
                //Bname = "buyer45",
                //Createddate = System.DateTime.Now,
                //Password = "ASDFGHJ*",

            });

        }

        [Test]
        [Description("Test seller registraction")]
        public void TestSellerRegistraction()
        {
            _repo.SellerRegister(new Seller()
            {
                Sid= 5,
                 Semail= "seller99@gmail.com",
                Sno = "9999999599",
                Sname = "seller5",
                //   Createddate = System.DateTime.Now,
                 Spwd = "ASDFGHJ*",
                 BreifAboutCompany  = "good ",
                 Scompany = "Infoview",
                Gstin=" 9",
                 PostalAddress = "chennai"

            });

        }
    }
}

