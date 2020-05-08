using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class SearchProductOptions
    {
        public int? ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductCategory { get; set; }
    }
}
