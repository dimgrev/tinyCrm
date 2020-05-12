using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;
using TinyCrm.Core.Services;

namespace TinyCrm.Core
{
    public class CustomerService : ICustomerService
    {
        private TinyCrmDbContext context_;
        public CustomerService(TinyCrmDbContext context) //Se ena constractor thn dbcontext
        {
            context_ = context;
        }
        public Customer CreateCustomer(CreateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var customer = new Customer()
            {
                Lastname = options.Lastname,
                Firstname = options.Firstname,
                VatNumber = options.VatNumber
            };

            context_.Add(customer);

            if (context_.SaveChanges() > 0)
            {
                return customer;
            }
            return null;
        }

        public Customer GetCustomerById(GetCustomerByIdOptions options)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
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

        public Customer UpdateCustomer(UpdateCustomerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

