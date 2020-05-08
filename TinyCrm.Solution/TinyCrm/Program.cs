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
            var tinyCrmDbContext = new TinyCrmDbContext();

            // Insert
            var customer = new Customer()
            {
                Firstname = "Xaris",
                Lastname = "Mpouras",
                Email = "mpouras.gr"
            };

            tinyCrmDbContext.Add(customer);

            var petrogiannos = new Customer()
            {
                Firstname = "Dimitris",
                Lastname = "Petrogiannos",
                Email = "petrogiannos.gr"
            };

            tinyCrmDbContext.Add(petrogiannos);
            tinyCrmDbContext.SaveChanges();

            // Get data
            var customer2 = tinyCrmDbContext
                .Set<Customer>()
                .Where(c => c.CustomerId == customer.CustomerId)
                .SingleOrDefault();

            // Update
            customer2.VatNumber = "123456789";
            tinyCrmDbContext.SaveChanges();

            // Delete
            tinyCrmDbContext.Remove(customer2);
            tinyCrmDbContext.SaveChanges();

            // Search
            var results = SearchCustomers(
                new SearchCustomerOptions()
                {
                    VatNumber = "117003949"
                }, tinyCrmDbContext)
                .Where(c => c.TotalGross > 500M)
                .Any();

            // ------------------------------
            var product = new Product()
            {
                ProductId = "PRD45454",
                Category = ProductCategory.Mobiles,
                Name = "IPhone 100",
                Price = 1500M
            };

            var order = new Order()
            {
                DeliveryAddress = "Athina TK 15343"
            };

            order.OrderProducts.Add(
                new OrderProduct(){
                    Product = product
                });

            var customerWithOrders = new Customer()
            {
                Firstname = "Dimitris",
                Lastname = "Tzempentzis",
                Email = "dtzempentzis@mail.com"
            };

            customerWithOrders.Orders.Add(order);

            tinyCrmDbContext.Add(customerWithOrders);
            tinyCrmDbContext.SaveChanges();
            // =================================

            // Select customer with orders
            var customer5 = SearchCustomers(
                new SearchCustomerOptions()
                {
                    CustomerId = 18
                }, tinyCrmDbContext)
                .Include(c => c.Orders)
                .SingleOrDefault();

            tinyCrmDbContext.Dispose();
        }

        public static IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options, TinyCrmDbContext dbContext)
        {
            if (options == null)
            {
                return null;
            }

            var query = dbContext
                .Set<Customer>()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.Firstname))
            {
                query = query.Where(c => c.Firstname == options.Firstname);
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(c => c.VatNumber == options.VatNumber);
            }

            if (options.CustomerId != null)
            {
                query = query.Where(c => c.CustomerId == options.CustomerId.Value);
            }

            if (options.CreatedFrom != null)
            {
                query = query.Where(c => c.Created >= options.CreatedFrom);
            }

            query = query.Take(500);

            return query;
        }
    }
}