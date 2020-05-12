using System;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services.Options
{
    public class SearchProductOptions
    {
        public string ProductId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public DateTimeOffset CreatedFrom { get; set; }
        public DateTimeOffset CreatedTo { get; set; }
        public ProductCategory? Category { get; set; }
    }
}
