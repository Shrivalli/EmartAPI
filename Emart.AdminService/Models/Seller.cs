using System;
using System.Collections.Generic;

namespace Emart.AdminService.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Items = new HashSet<Items>();
            PurchaseHistory = new HashSet<PurchaseHistory>();
        }

        public int Sid { get; set; }
        public string Sname { get; set; }
        public string Spwd { get; set; }
        public string Semail { get; set; }
        public string Sno { get; set; }
        public string Scompany { get; set; }
        public string Gstin { get; set; }
        public string BreifAboutCompany { get; set; }
        public string PostalAddress { get; set; }

        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<PurchaseHistory> PurchaseHistory { get; set; }
    }
}
