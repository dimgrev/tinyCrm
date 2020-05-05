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
            var tinyCrmDbContext = new TinyCrmDbContext();

            // Insert
            var customer = new Customer()
            {
                Firstname = "Dimitris",
                Lastname = "Grevenos",
                Email = "Dimitrisgr@outlook.com",

            };

            tinyCrmDbContext.Add(customer);
            tinyCrmDbContext.SaveChanges();

            //Get Data  SingleOrDefault gia monadikes eggrafes enw FirsOrDefault gia ta alla
            var customer2 = tinyCrmDbContext
                .Set<Customer>()
                //.ToList() //8a sou ferei oles tis eggrafes pou exei sto disko
                .Where(x => x.CustomerId == customer.CustomerId)
                .Where(x => x.Email == "Dimitrisgr@outlook.com");

            // Materialization function. !Set breakpoint above and then check Server Profiler
            var results = customer2.SingleOrDefault();

            //Update Entity (Set VatNumber)
            results.VatNumber = "123456789";
            tinyCrmDbContext.SaveChanges();

            //Delete an Entity
            tinyCrmDbContext.Remove(customer2);
            tinyCrmDbContext.SaveChanges();

        }
            
    }
}