using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCrm
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public decimal TotalGross { get; private set; }
        public bool IsActive { get; set; }
        public List<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }

        //Search Customers by Options

        public static IQueryable<Customer> SearchCustomers(SearchCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }

            using (var dbcontex = new TinyCrmDbContext())
            {
                var iQuery = dbcontex.Set<Customer>().AsQueryable();

                if (!string.IsNullOrWhiteSpace(options.Firstname))
                {
                    iQuery = iQuery.Where(c => c.Firstname.Contains(options.Firstname)); // Sth bash to kanei me ignore case
                }
                if (!string.IsNullOrWhiteSpace(options.Lastname))
                {
                    iQuery = iQuery.Where(c => c.Firstname.Contains(options.Lastname));
                }
                if (!string.IsNullOrWhiteSpace(options.VatNumber))
                {
                    iQuery = iQuery.Where(c => c.Firstname == options.VatNumber); // Sth bash to kanei me ignore case
                }
                if (options.CustomerId != null)
                {
                    iQuery = iQuery.Where(c => c.CustomerId == options.CustomerId);
                }
                if (options.CreatedFrom > DateTime.MinValue && options.CreatedTo < DateTime.Now)
                {
                    iQuery = iQuery.Where(c => c.Created > options.CreatedFrom && c.Created < options.CreatedTo);
                }

                var newQuery = iQuery.Select(c => new { c.CustomerId, c.Email });
                iQuery = iQuery.Take(500);

                return iQuery;
            }

        }
    }
}
