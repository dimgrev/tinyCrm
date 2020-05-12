using System.Collections.Generic;

namespace TinyCrm.Core.Services.Options
{
    public class CreateOrderOptions
    {
        public int CustomerId { get; set; }
        public string DeliveryAddress { get; set; }
        public List<string> ProductIds { get; set; }

        public CreateOrderOptions()
        {
            ProductIds = new List<string>();
        }
    }
}
