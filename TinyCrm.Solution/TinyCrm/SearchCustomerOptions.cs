using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class SearchCustomerOptions
    {
        public int? CustomerId { get; set; }
        public DateTimeOffset? CreatedFrom { get; set; }
        public DateTimeOffset? CreatedTo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public decimal TotalGross { get; private set; }
        public bool IsActive { get; set; }


    }
}
