using System;
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

        public Result<Customer> CreateCustomer(
            CreateCustomerOptions options)
        {
            var result = new Result<Customer>();//Result typou customer
            //result.Data.CustomerId = 1;////Gia paradeigma
            
            if (options == null)
            {
                return Result<Customer>.CreateFailed(StatusCode.BadRequest, "Null options");
                // ^
                //result.ErrorCode = StatusCode.BadRequest;
                //result.ErrorText = "Null options";
                //return result;
            }

            if (string.IsNullOrWhiteSpace(options.VatNumber))
            {
                return Result<Customer>.CreateFailed(StatusCode.BadRequest, "Null or Empty VatNumber");
                //result.ErrorCode = StatusCode.BadRequest;
                //result.ErrorText = "Null or Empty VatNumber";
                //return result;
            }

            var customer = new Customer()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Email = options.Email,
                VatNumber = options.VatNumber,
                Phone = options.Phone,
                IsActive = true
            };

            context_.Add(customer);

            var rows = 0;

            try
            {
                rows = context_.SaveChanges();
                if (rows <= 0)
                {
                    return Result<Customer>.CreateFailed(StatusCode.InternalServerError, "Customer could not be updated");
                }
            }
            catch (Exception ex)
            {
                return Result<Customer>.CreateFailed(StatusCode.InternalServerError, ex.ToString());
            }

            return Result<Customer>.CreateSuccessful(customer);
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
                query = query.Where(c => c.CustomerId == options.CustomerId);
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
            if (options == null || id == 0)
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
                customer.IsActive = options.IsActive.Value;

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

        public bool DeleteCustomer(int id)
        {
            if (id == 0)
            {
                return false;
            }

            var query = context_
                .Set<Customer>()
                .AsQueryable();

            if (id > 0)
            {
                var customer = query.Where(c => c.CustomerId == id).SingleOrDefault();

                context_.Remove(customer);

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
