using System.Linq;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services.Interfaces
{
    public interface IProductService
    {
        Product CreateProduct(
            CreateProductOptions options);
        IQueryable<Product> SearchProducts(
            SearchProductOptions options);
        bool UpdateProduct(
            UpdateProductOptions options);
        IQueryable<Product> GetProductById(
            string id);
    }
}
