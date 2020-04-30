using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public int TotalAmount { get; set; }

    }
}
