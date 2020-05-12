using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TinyCrm.Core.Services;
using TinyCrm.Core.Data;
using TinyCrm.Core.Services.Options;
using TinyCrm.Core;

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
                    CustomerId = 4
                    }).SingleOrDefault();

            }
            
            //using (var context = new TinyCrmDbContext())
            //{
            //    var cService = new CustomerService(context);
            //    var pService = new ProductService(context);
            //    // oxi var allo customerService type
            //    IOrderService orderService = new OrderService(
            //        context, cService, pService);

            //    var newProductsIds = new List<string>();
            //    newProductsIds.Add("PRD45454");
            //    newProductsIds.Add("PRD46464");
            //    newProductsIds.Add("PRD47474");

            //    var result = orderService.CreateOrder(new CreateOrderOptions()
            //    {
            //        DeliveryAddress = "Aigaleo TK 12241",
            //        CustomerId = 14,
            //        ProductsIds = newProductsIds
            //    });

            //    Console.WriteLine($"New Order = {result.OrderId} & DeliveryAddress = {result.DeliveryAddress} ");
            //    foreach (var item in result.OrderProducts)
            //    {
            //        Console.WriteLine($"Order Product = {item.ProductId}");
            //    }
            //}
        }
    }
}