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

            var tinyCrmDbContext = new TinyCrmDbContext();

            if (csvList.Length == 0)
            {
                return;
            }
            else
            {
                //Insert Data To database
                var listOfProducts = new List<Product>();

                for (int i = 0; i < csvList.Length; i++)
                {
                    var values = csvList[i].Split(';');
                    var duplicateId = Guid.Parse(values[0]);

                    var dl = listOfProducts.Where(x => x.ProductId.Equals(duplicateId));

                    if (dl.Count() > 0 )
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

                        tinyCrmDbContext.Add(product);
                        tinyCrmDbContext.SaveChanges();
                    }

                }
                
                Console.WriteLine("Insert Raw Data into the DataBase Done Succesfully!");
                Console.ReadLine();
            }

        }
            
    }
}