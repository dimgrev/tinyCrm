using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services.Options
{
    public class CreateProductOptions
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategory? ProductCategory { get; set; }
    }
}
