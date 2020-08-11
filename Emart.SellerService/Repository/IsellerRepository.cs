using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emart.SellerService.Models;


namespace Emart.SellerService.Repository
{
    public interface IsellerRepository
    {

        void EditProfile(Seller obj);

        Seller getprofile(int sid);


    }
}