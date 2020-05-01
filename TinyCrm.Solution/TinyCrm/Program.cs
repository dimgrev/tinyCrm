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
            
            string[] csvList;
            try
            {
                csvList = File.ReadAllLines("Product.csv").Skip(1).ToArray();
            }
            catch (Exception)
            {
                return;
            }

            if (csvList.Length == 0)
            {
                return;
            }
            else
            {
                var listOfProducts = new List<Product>();

                for (int i = 0; i < csvList.Length; i++)
                {
                    var values = csvList[i].Split(';');
                    var productId = Guid.Parse(values[0]);

                    var l = listOfProducts.Where(x => x.ProductId.Equals(productId));

                    if (l.Count() > 0)
                    {
                        continue;
                    }
                    else
                    {
                        var product = new Product()
                        {
                            ProductId = Guid.Parse(values[0]),
                            Name = values[1],
                            Description = values[2],
                            Price = Product.GetRndPrice()
                        };

                        listOfProducts.Add(product);

                        const string format = "{0,-60} {1,-35} {2,-60} {3,-20} {4}";

                        Console.WriteLine(format, $"\nProduct ID: {product.ProductId}", $"List item Name: {product.Name}", $"Description: {product.Description}", $"Price: {product.Price}$", $"ProductNum: {i}");
                    }
                }

                int[] numb;
                Random rnd = new Random();

                List<Customer> lCustomers = new List<Customer>();

                numb = Enumerable.Range(1, 2).ToArray();
                foreach (var item in numb)
                {
                    lCustomers.Add(new Customer($"{rnd.Next(100000000,999999999)}"));
                }
                Console.WriteLine("\n");
                foreach (var item in lCustomers)
                {
                    item.Age = rnd.Next(18, 80);
                    item.OrderList = listOfProducts.OrderBy(x => rnd.Next()).Take(10).ToList();
                    
                    var order1 = new Order();
                    item.TotalGross = order1.GetTotalAmount(item.OrderList);
                    
                    Console.WriteLine($"Customer VatNum is: {item.VatNumber}");
                    Console.WriteLine($"Customer TotalGross is: {item.TotalGross}");

                    if (item == lCustomers.First())
                    {
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine($"\n\tStatistics!\n");

                var maxObject = lCustomers.OrderByDescending(item => item.TotalGross).First();
                Console.WriteLine($" The Customer with max TotalGross (The most valuable customer)" +
                    $" is the one with VatNumber: {maxObject.VatNumber}\n");

                Console.WriteLine($" The 5 most sold products are:\n");
                foreach (var item in lCustomers.First().OrderList)
                {
                    var pi1 = item.ProductId;
                    var pi2 = lCustomers.Skip(1).First().OrderList;

                    foreach (var item2 in pi2)
                    {
                        if ( item2.ProductId == pi1 )
                        {
                            item.Orders++;
                            item2.Orders++;
                        }
                    }
                    
                }
                var x = lCustomers.Skip(1).First().OrderList.OrderByDescending(y => y.Orders).Take(5);
                if (x != null)
                {
                    foreach (var item3 in x)
                    {
                        Console.WriteLine($"PID: {item3.ProductId} & Num of Orders: {item3.Orders} & Price: {item3.Price}");
                    }
                }
                else
                {
                    Console.WriteLine($"There were not products with more than 1 order.");
                }
                //foreach (var item3 in lCustomers.First().OrderList)
                //{
                //    Console.WriteLine($"COrderList1PID: {item3.Orders}");
                //}
                //foreach (var item4 in lCustomers.Skip(1).First().OrderList)
                //{
                //    Console.WriteLine($"COrderList2PID: {item4.Orders}");
                //}

                //int[] pNum;
                //List<string> pCustomerName;

                //pCustomerName = new List<string>();
                //pNum = Enumerable.Range(1, 2).ToArray();
                //foreach (int num in pNum)
                //    pCustomerName.Add("Customer" + num.ToString());
                //foreach (string name in pCustomerName)
                //{
                //    Console.WriteLine($"Customer Name is: {name}");
                //}

                //var customer1 = new Customer("123456789");
                //var customer2 = new Customer("234567890");

                ////Random rnd = new Random();

                //var OrderList = new List<Product>();

                //customer1.OrderList = listOfProducts.OrderBy(x => rnd.Next()).Take(10).ToList();
                //customer2.OrderList = listOfProducts.OrderBy(x => rnd.Next()).Take(10).ToList();

                //var order1 = new Order();

                //order1.OrderList = customer1.OrderList;
                //var total1 = order1.GetTotalAmount(order1.OrderList);

                //Console.WriteLine($"TOTAL1 !!!{total1}");

                //Console.WriteLine($"Customer 1 List is:\n");
                //foreach (var item in customer1.OrderList)
                //{
                //    Console.WriteLine($"{item.ProductId}");
                //}

                //Console.WriteLine($"Customer 2 List is:\n");
                //foreach (var item in customer2.OrderList)
                //{
                //    Console.WriteLine($"{item.ProductId}");
                //}
            }

        }
    }
}