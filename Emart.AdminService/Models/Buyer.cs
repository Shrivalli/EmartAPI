using System;
using System.Collections.Generic;

namespace Emart.AdminService.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            PurchaseHistory = new HashSet<PurchaseHistory>();
        }

        public int Bid { get; set; }
        public string Bname { get; set; }
        public string Bpwd { get; set; }
        public string Bemail { get; set; }
        public string Bno { get; set; }
        public DateTime? Bdate { get; set; }

        public virtual ICollection<PurchaseHistory> PurchaseHistory { get; set; }
    }
}
