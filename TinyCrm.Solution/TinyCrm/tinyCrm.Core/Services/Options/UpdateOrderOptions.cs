using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Services.Options
{
    public class UpdateOrderOptions
    {
        public int OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public int CustomerId { get; set; }
        public List<string> OrderProducts { get; set; }
    }
}
