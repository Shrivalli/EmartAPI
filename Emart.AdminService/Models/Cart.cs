using System;
using System.Collections.Generic;

namespace Emart.AdminService.Models
{
    public partial class Cart
    {
        public int Cartid { get; set; }
        public int? Iid { get; set; }
        public int? Cid { get; set; }
        public int? Scid { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public int? StockNo { get; set; }
        public int? Sid { get; set; }
        public int? Bid { get; set; }
        public string Imagepath { get; set; }
        public string ItemName { get; set; }
    }
}
