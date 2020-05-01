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
        public List<Product> OrderList { get; set; }
            
        public decimal GetTotalAmount(List<Product> orderList)
        {
            decimal total = 0;
            foreach (var item in orderList)
            {
                total = total + item.Price; 
            }
            return total;
        }

    }
}
