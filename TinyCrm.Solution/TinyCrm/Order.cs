using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; set; }
            

        public Order()
        {
            Created = DateTimeOffset.Now;
        }

    }
}
