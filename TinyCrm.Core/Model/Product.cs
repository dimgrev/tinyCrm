using System;

namespace TinyCrm.Core.Model
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductCategory? Category { get; set; }

        public Product()
        {
            Created = DateTime.Now;
            Price = Product.GetRndPrice();
        }

        public static decimal GetRndPrice()
        {

            Random rnd = new Random();
            var rndNumber = rnd.NextDouble() * 100;
            var roundedNumber = Math.Round(rndNumber, 2);
            // product.Price = (decimal)roundedNumber;
            var decimalNum = Convert.ToDecimal(roundedNumber);

            return decimalNum;
        }
    }
}
