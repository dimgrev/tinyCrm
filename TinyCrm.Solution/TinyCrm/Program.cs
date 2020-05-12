using System;
using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Interfaces;
using TinyCrm.Core.Services.Options;

namespace TinyCrm
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TinyCrmDbContext())
            {
                ICustomerService customerService = new CustomerService(
                    context);

                var results = customerService.CreateCustomer(
                    new CreateCustomerOptions()
                    {
                        FirstName = "Dimitris",
                        LastName = "grevenos",
                        Email = "Dimgrev@gmail.com",
                        Phone = "6988776655",
                        VatNumber = "123456789",
                        IsActive = true,
                    });
            }

        }
    }
}