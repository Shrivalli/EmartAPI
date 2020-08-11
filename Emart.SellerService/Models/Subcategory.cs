using System;
using System.Collections.Generic;

namespace Emart.SellerService.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Items = new HashSet<Items>();
        }

        public int Scid { get; set; }
        public string Sname { get; set; }
        public string Scdetails { get; set; }
        public int? Cid { get; set; }
        public string Gst { get; set; }

        public virtual Category C { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
