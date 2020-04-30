using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    var dGrevenos = new Customer("123123");

            //    //var dGrevenos = Customer.CreateCustomer("123456789");
            //    //System.IO.File.ReadAllLines("path"); divazei oles tis grames enws arxeiou
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Please re enter {ex.Message} \n\n Static text is: {Customer.Text}");
            //}
            
            List<Product> values = File.ReadAllLines("Product.csv")
                .Skip(1)
                .Select(v => Product.SetValuesFromCsv(v))
                .ToList();

            var y = 0;
            foreach (var item in values)
            {
                const string format = "{0,-45} {1,-20} {2}";
                y++;
                Console.WriteLine(format,$"Product Name is: {item.Name}", $"Price: {item.Price} $",$" ProductNum: {y}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t\t\t----NON DUPLICATED LIST----");
            Console.ResetColor();

            var distinctItems = values.GroupBy(x => x.ProductId).Select(y => y.First());

            //var distinctItems = values.DistinctBy(x => x.ProductId).ToList();

            //var groupedLessons = from l in values
            //                     group l by l.ProductId into g
            //                     where g.Count() > 1
            //                     select new { ProductId = g.Key, values = g };

            //foreach (var k in groupedLessons)
            //{
            //    Console.WriteLine("ProductId: " + k.ProductId);

            //    foreach (var l in k.values)
            //    {
            //        Console.WriteLine($"\t Lesson Title: " + l.Name);
            //    }
            //}

            var x = 0;
            foreach (var item in distinctItems)
            {
                const string format = "{0,-60} {1,-35} {2,-60} {3,-20} {4}";
                x++;
                Console.WriteLine(format,$"\nProduct ID: {item.ProductId}",$"List item Name: {item.Name}",$"Description: {item.Description}",$"Price: {item.Price}$",$"ProductNum: {x}");
            }

            //dGrevenos.VatNumber = "123456789";
            //dGrevenos.IsValidEmail();

        }


    }
}