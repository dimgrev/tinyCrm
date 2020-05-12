using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Services.Options
{
    public class SearchOrdersOptions
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
