using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    class Product
    {
        public Guid ProductId { get; private set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        
        public static Product SetValuesFromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');

            Product product = new Product();

            
            product.ProductId = Guid.Parse(values[0]);

            product.Name = values[1];

            product.Description = values[2];

            Random rnd = new Random();
            var rndNumber = rnd.NextDouble() * 100;
            var roundedNumber = Math.Round(rndNumber, 2);
            // product.Price = (decimal)roundedNumber;
            var decimalNum = Convert.ToDecimal(roundedNumber);
            product.Price = decimalNum;

            
            return product;
        }

        public string GetAllProducts(Product x)
        {
            foreach (var item in Name)
            {
                Console.WriteLine($"Product Name is: {Name}");
            }
            return this.Name;
        }



    }
}
