using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Interfaces;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class ProductService : IProductService
    {
        private TinyCrmDbContext context_;

        public ProductService(TinyCrmDbContext context)
        {
            context_ = context;
        }
        public Product CreateProduct(CreateProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var product = new Product()
            {
                ProductId = options.ProductId,
                Name = options.Name,
                Description = options.Description,
                Category = options.ProductCategory.Value,
                Price = options.Price,
            };

            context_.Add(product);

            if (context_.SaveChanges() > 0)
            {
                return product;
            }

            return null;
        }

        public IQueryable<Product> GetProductById(string id)
        {
            if (id != null)
            {
                var query = context_
                .Set<Product>()
                .AsQueryable();

                query = query.Where(c => c.ProductId == id);

                return query;
            }

            return null;
        }

        public IQueryable<Product> SearchProducts(SearchProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                .Set<Product>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.ProductId))
            {
                query = query.Where(c => c.ProductId == options.ProductId);
            }
            if (!string.IsNullOrWhiteSpace(options.Name))
            {
                query = query.Where(c => c.Name == options.Name);
            }
            if (!string.IsNullOrWhiteSpace(options.Description))
            {
                query = query.Where(c => c.Description.Contains(options.Description));
            }
            if (options.PriceFrom >= 0)
            {
                query = query.Where(c => c.Price >= options.PriceFrom);
            }
            if (options.PriceTo >= 0)
            {
                query = query.Where(c => c.Price <= options.PriceTo);
            }
            if (options.CreatedFrom != null)
            {
                query = query.Where(c => c.Created <= options.CreatedFrom);
            }
            if (options.CreatedTo != null)
            {
                query = query.Where(c => c.Created <= options.CreatedTo);
            }
            if (options.Category >= 0)
            {
                query = query.Where(c => c.Category == options.Category);
            }

            query = query.Take(500);

            return query;
        }

        public bool UpdateProduct(UpdateProductOptions options)
        {
            if (options == null)
            {
                return false;
            }

            var query = context_
                .Set<Product>()
                .AsQueryable();

            var product = query.Where(c => c.ProductId == options.ProductId).SingleOrDefault();

            product = new Product()
            {
                ProductId = options.ProductId,
                Name = options.Name,
                Description = options.Description,
                Category = options.Category,
                Price = options.Price,
            };

            if (context_.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
