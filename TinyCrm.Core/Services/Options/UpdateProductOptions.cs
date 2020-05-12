using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services.Options
{
    public class UpdateProductOptions
    {
        public string ProductId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
    }
}
