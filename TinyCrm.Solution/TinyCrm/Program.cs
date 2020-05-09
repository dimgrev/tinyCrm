using Microsoft.EntityFrameworkCore;
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
            using (var context = new TinyCrmDbContext())
            {
                // oxi var allo customerService type
                ICustomerService customerService = new CustomerService(
                    context);

                var resuts = customerService.SearchCustomers(
                    new SearchCustomerOptions()
                    {
                    CustomerId = 3
                    }).SingleOrDefault();
            }
            
        }
    }
}