using MoreLinq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Insert Random Customers into DataBase table Customers
            
            //int[] numb;
            //Random rnd = new Random();

            //List<Customer> lCustomers = new List<Customer>();
            //var tinyCrmDbContext = new TinyCrmDbContext();

            //numb = Enumerable.Range(1, 5).ToArray();
            //foreach (var item in numb)
            //{
            //    var customer1 = new Customer();
            //    customer1.Firstname = "Dimitris" + item;
            //    customer1.Lastname = "Grevenos" + item;
            //    customer1.VatNumber = "12345678" + item;
            //    customer1.Email = "DimitrisGrevenos" + item + "@gmail.com";

            //    lCustomers.Add(customer1);
            //    tinyCrmDbContext.Add(customer1);
            //    tinyCrmDbContext.SaveChanges();
            //}

            //Search Customers with Filters

            int id = default(int);
            DateTime crFrom = default(DateTime);
            DateTime crTo = default(DateTime);

            Console.WriteLine("\t\nWelcome To Our Customers Catalog Search Engine");
            Console.WriteLine("\nSearch customers by these criteria:\n" +
                "1.Firstname\n" +
                "2.Lastname\n" +
                "3.VatNumber\n" +
                "4.CreatedFrom & CreatedTo\n" +
                "5.CustomerId\n");
            
            Console.WriteLine("Search option by FirstName!\n" +
                " Insert FirstName with which you would like to search Customers List:");
            var value1 = Console.ReadLine();
            Console.WriteLine("Search option Lastname! if you dont want to give any press enter.\n" +
                " Insert Lastname:");
            var value2 = Console.ReadLine();
            Console.WriteLine("Search option VatNumber! if you dont want to give any press enter.\n" +
                " Insert VatNumber:");
            var value3 = Console.ReadLine();
            Console.WriteLine("Search option Id! if you dont want to give any press enter.\n" +
                " Insert Id:");
            id = Convert.ToInt32(int.TryParse(Console.ReadLine(), out id));
            Console.WriteLine("Search option CreatedFrom! if you dont want to give any press enter.\n" +
                " Insert CreatedFrom:");
            DateTime.TryParseExact(Console.ReadLine(), "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out crFrom);
            Console.WriteLine("Search option CreatedTo! if you dont want to give any press enter.\n" +
                " Insert CreatedTo:");
            DateTime.TryParseExact(Console.ReadLine(), "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out crTo);
            var results = Customer.SearchCustomers(value1, value2, value3, id, crFrom, crTo);
            if (results != null)
            {
                results.ForEach(i => Console.Write($"{i.Firstname}\t"));
            }
            else
            {
                Console.Write($"No given criteria\n");
            }
            
        }
            
    }
}