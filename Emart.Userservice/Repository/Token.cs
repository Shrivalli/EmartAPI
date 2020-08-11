using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart.Userservice.Repository
{
    public class Token
    {
        public int sid { get; set; }
        public int bid { get; set; }
         public string token { get; set; }
        public string message { get; set; }
    }
}
