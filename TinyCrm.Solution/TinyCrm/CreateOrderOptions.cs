using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class CreateOrderOptions
    {
        public int CustomerId { get; set; }

        public List<string> ProductsIds { get; set; }

        public CreateOrderOptions()
        {
            ProductsIds = new List<string>();
        }
    }
}
