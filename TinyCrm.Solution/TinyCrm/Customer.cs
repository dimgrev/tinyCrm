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
        public List<Product> OrderList { get; set; }



        //Search Customers by Options
        public static List<Customer> SearchCustomers(string value1, string value2, string value3, int id, DateTime crFrom, DateTime crTo)
        {
            var tinyCrmDbContext = new TinyCrmDbContext();
            List<Customer> newCustomers = null;
            List<Customer> customers = null;
            List<Customer> customersResults = null;

            var x = DateTime.Now;

            var r = tinyCrmDbContext.Set<Customer>();

            if (!string.IsNullOrWhiteSpace(value1))
            {
                newCustomers = r.Where(w => w.Firstname.Contains(value1)).ToList();
                customers = newCustomers;
            }
            if (!string.IsNullOrWhiteSpace(value2))
            {
                newCustomers = r.Where(w => w.Lastname.Contains(value2)).ToList();
                customers.AddRange(newCustomers);
            }
            if (!string.IsNullOrWhiteSpace(value3))
            {
                newCustomers = r.Where(w => w.VatNumber.Contains(value3)).ToList();
                customers.AddRange(newCustomers);
            }
            if (id >= 0)
            {
                newCustomers = r.Where(w => w.CustomerId == id).ToList();
                customers.AddRange(newCustomers);
            }
            if (crTo < DateTime.Now && crFrom > DateTime.MinValue)
            {
                newCustomers = r.Where(w => w.Created > crFrom && w.Created < crTo).ToList();
                customers.AddRange(newCustomers);
            }

            customersResults = customers.Distinct().ToList();

            return customersResults;
        }
    }
}
