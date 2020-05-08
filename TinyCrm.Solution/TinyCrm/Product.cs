using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCrm
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }



        //public Guid ProductId { get; set; }
        //public string Description { get; set; }
        //public string Name { get; set; }
        //public decimal Price { get; set; }
        //public int Orders { get; set; }
        //public List<Order> OrderList { get; set; }

        public static decimal GetRndPrice()
        {

            Random rnd = new Random();
            var rndNumber = rnd.NextDouble() * 100;
            var roundedNumber = Math.Round(rndNumber, 2);
            // product.Price = (decimal)roundedNumber;
            var decimalNum = Convert.ToDecimal(roundedNumber);

            return decimalNum;
        }


        public static List<Product> SearchProductsO(string value1, string value2, decimal priceFrom, decimal priceTo)
        {
            var tinyCrmDbContext = new TinyCrmDbContext();
            List<Product> newProducts = null;
            List<Product> products = null;
            List<Product> productsResults = null;

            var x = DateTime.Now;

            var r = tinyCrmDbContext.Set<Product>();

            if (!string.IsNullOrWhiteSpace(value1))
            {
                newProducts = r.Where(w => w.ProductId.Equals(value1)).ToList();
                products = newProducts;
            }
            if (!string.IsNullOrWhiteSpace(value2))
            {
                //newProducts = r.Where(w => w.Category.Contains(value2)).ToList();
                products.AddRange(newProducts);
            }
            if (priceTo < 150 && priceFrom > 0)
            {
                newProducts = r.Where(w => w.Price > priceFrom && w.Price < priceTo).ToList();
                products.AddRange(newProducts);
            }

            productsResults = products.Distinct().ToList();

            return productsResults;
        }

        public static IQueryable<Product> SearchProducts(SearchProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            using (var dbcontex = new TinyCrmDbContext())
            {
                var iQuery = dbcontex.Set<Product>().AsQueryable();

                if (options.ProductId != null)
                {
                    //iQuery = iQuery.Where(c => c.ProductId == options.ProductId); // Sth bash to kanei me ignore case
                }
                if (!string.IsNullOrWhiteSpace(options.ProductCategory))
                {
                    //iQuery = iQuery.Where(c => c.ProductCategory.Contains(options.ProductCategory));
                }

                iQuery = iQuery.Take(500);

                return iQuery;
            }
        }
    }
}
