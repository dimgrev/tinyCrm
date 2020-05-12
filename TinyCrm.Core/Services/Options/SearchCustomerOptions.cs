using System;

namespace TinyCrm.Core.Services.Options
{
    public class SearchCustomerOptions
    {
        public int? CustomerId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; private set; }
        public string Phone { get; set; }
        public decimal? TotalGross { get; set; }
        public DateTimeOffset? CreateFrom { get; set; }
        public DateTimeOffset? CreatedTo { get; set; }
        public bool? IsActive { get; set; }
    }
}
