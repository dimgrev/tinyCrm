using System;
using System.Collections.Generic;
using System.Linq;

namespace TinyCrm.Core.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VatNumber { get; set; }
        public decimal TotalGross { get; set; }
        public bool? IsActive { get; set; }

        public List<Order> Orders { get; set; }

        public Customer()
        {
            Created = DateTimeOffset.Now;
            Orders = new List<Order>();
        }

        public bool IsValidVatNumber(string vatNumber)
        {
            return
                !string.IsNullOrWhiteSpace(vatNumber) &&
                vatNumber.Length == 9;
        }

        public bool IsValidEmail(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail))
            {
                return false;
            }

            mail = mail.Trim();

            if (mail.Contains("@") && mail.EndsWith(".com"))
            {
                var count = mail.Count(x => x == '@');

                return count == 1;
            }
            return false;
        }

        public bool IsAdult(int age)
        {
            return age >= 18 && age <= 120;
        }

    }
}
