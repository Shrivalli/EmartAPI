using System;
using System.Collections.Generic;

namespace Emart.AdminService.Models
{
    public partial class Transactions
    {
        public int TransactionId { get; set; }
        public int? Sid { get; set; }
        public int? Bid { get; set; }
        public string TransactionType { get; set; }
        public DateTime? DateTime { get; set; }
        public string Remarks { get; set; }

        public virtual Buyer B { get; set; }
        public virtual Seller S { get; set; }
    }
}
