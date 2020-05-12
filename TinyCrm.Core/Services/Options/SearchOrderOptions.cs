using System;

namespace TinyCrm.Core.Services.Options
{
    public class SearchOrderOptions
    {
        public int? OrderId { get; private set; }
        public string DeliveryAddress { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public DateTimeOffset? CreatedFrom { get; set; }
        public DateTimeOffset? CreatedTo { get; set; }
    }
}
