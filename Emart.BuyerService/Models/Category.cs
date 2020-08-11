using System;
using System.Collections.Generic;

namespace Emart.BuyerService.Models
{
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Items>();
            Subcategory = new HashSet<Subcategory>();
        }

        public int Cid { get; set; }
        public string Cname { get; set; }
        public string Cdetails { get; set; }

        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
}
