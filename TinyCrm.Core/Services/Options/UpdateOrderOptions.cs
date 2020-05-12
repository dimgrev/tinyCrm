using System.Collections.Generic;

namespace TinyCrm.Core.Services.Options
{
    public class UpdateOrderOptions
    {
        public int? OrderId { get; private set; }
        public string DeliveryAddress { get; set; }
        public List<string> ProductIds { get; set; }

        public UpdateOrderOptions()
        {
            ProductIds = new List<string>();
        }
    }
}
