using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Order> OrderList { get; set; }



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
    }
}
