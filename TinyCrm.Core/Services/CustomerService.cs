using System.Linq;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Interfaces;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private TinyCrmDbContext context_;

        public CustomerService(TinyCrmDbContext context)
        {
            context_ = context;
        }

        public Customer CreateCustomer(
            CreateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var customer = new Customer()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Email = options.Email,
                VatNumber = options.VatNumber,
                Phone = options.Phone,
                IsActive = options.IsActive,
            };

            context_.Add(customer);

            if (context_.SaveChanges() > 0)
            {
                return customer;
            }

            return null;
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

            if (!string.IsNullOrWhiteSpace(options.FirstName))
            {
                query = query.Where(c => c.FirstName.Contains(options.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(options.LastName))
            {
                query = query.Where(c => c.LastName.Contains(options.LastName));
            }

            if (!string.IsNullOrWhiteSpace(options.Email))
            {
                query = query.Where(c => c.LastName.Contains(options.Email));
            }

            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(c => c.VatNumber.Contains(options.VatNumber));
            }

            if (!string.IsNullOrWhiteSpace(options.Phone))
            {
                query = query.Where(c => c.Phone.Contains(options.Phone));
            }

            if (options.CustomerId != null)
            {
                query = query.Where(c => c.CustomerId == options.CustomerId.Value);
            }

            if (options.CreateFrom != null)
            {
                query = query.Where(c => c.Created >= options.CreateFrom);
            }

            if (options.CreatedTo != null)
            {
                query = query.Where(c => c.Created <= options.CreatedTo);
            }

            query = query.Take(500);

            return query;
        }

        public bool UpdateCustomer(int id, UpdateCustomerOptions options)
        {
            if (options == null)
            {
                return false;
            }

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            if (id > 0)
            {
                var customer = query.Where(c => c.CustomerId == id).SingleOrDefault();
                customer.FirstName = options.FirstName;
                customer.LastName = options.LastName;
                customer.Email = options.Email;
                customer.IsActive = options.IsActive;

                if (context_.SaveChanges() > 0)
                {
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        public IQueryable<Customer> GetCustomerById(int id)
        {
            if (id >= 0)
            {
                var query = context_
                .Set<Customer>()
                .AsQueryable();

                query = query.Where(c => c.CustomerId == id);

                return query;
            }

            return null;
        }
    }
}
