using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Business
{
    public class Claim
    {
        public int MemberID { get; set; }
        public string ClaimDate { get; set; }
        public decimal ClaimAmount { get; set; }
    }
}
