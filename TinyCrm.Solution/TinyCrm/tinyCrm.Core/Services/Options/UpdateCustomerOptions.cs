using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Services.Options
{
    public class UpdateCustomerOptions
    {
        public int CustomerId { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
