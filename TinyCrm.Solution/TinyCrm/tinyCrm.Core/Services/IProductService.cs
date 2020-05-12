using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface IProductService
    {
        Product CreateProduct(
            CreateProductOptions options);
        bool UpdateProduct(
            UpdateProductOptions options);
        Product SearchProduct(
            SearchProductOptions options);
        Product GetProductById(
            string id);
    }
}
