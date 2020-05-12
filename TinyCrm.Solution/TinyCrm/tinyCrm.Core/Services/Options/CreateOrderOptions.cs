using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Services.Options
{
    public class CreateOrderOptions
    {
        public string DeliveryAddress { get; set; }
        public int CustomerId { get; set; }

        public List<string> ProductsIds { get; set; }

        public CreateOrderOptions()
        {
            ProductsIds = new List<string>();
        }
    }
}
