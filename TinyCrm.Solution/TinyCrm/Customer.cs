using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm
{
    public class Customer
    {
        //propfull tab tab with getter and setter
        //public static string Text = "This is a static text! that all objects has the same.";
        public Guid CustomerId { get; set; }
        public string Email { get; set; } //prop tab tab
        public string VatNumber { get; set; }
        private string FirstName { get; set; }//Getter & Setter underneath (beneath)
        private string LastName { get; set; }
        public DateTime CreatedTime { get; private set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public List<Product> OrderList { get; set; }
        public decimal TotalGross { get; set; }//Ara h get menei public

        //Constractor
        public Customer(string vatNumber)
        {
            if (IsValidVatNumber(vatNumber))
            {
                this.VatNumber = vatNumber;
                this.CreatedTime = DateTime.Now;//Trexousa hmera kai wra
            }
            else
            {
                throw new Exception("VatNumber is invalid");
            }

        }
        //Constractor not nesessary but if is it show it must be declared the property
        //public Customer(string vatNumber)
        //{
        //    VatNumber = vatNumber;
        //}

        //public bool IsHighValueCustomer()
        //{
        //    return TotalGross > 10000M;
        //}

        //public void SetPhone(string phone)
        //{
        //    Phone = phone;
        //}


        ////Setter &
        //public void SetFirstName(string firstName)
        //{
        //    this.FirstName = firstName;
        //}
        ////Getter
        //public string GetFirstName()
        //{
        //    return this.FirstName;
        //}

        public bool IsValidVatNumber(string vatNumber)
        {
            if (string.IsNullOrWhiteSpace(vatNumber))
            {
                return false;
            }
            vatNumber = vatNumber.Trim();
            if (vatNumber.Length == 9)
            {
                foreach (char y in vatNumber)
                {
                    if (y < '0' || y > '9')
                        return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsValidEmail()
        {
            var x = default(int);// value = 0 in string = null and in bool = false
            if (!string.IsNullOrWhiteSpace(Email))
            {
                Email = Email.Trim();
                foreach (var i in Email)
                {
                    if (i == '@')
                    {
                        x++;
                    }
                }
                if (x == 1)
                {
                    if (Email.EndsWith(".com") || Email.EndsWith(".gr"))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool IsAdult()
        {
            return Age >= 18;
        }

        public static Customer CreateCustomer(string vatNumber)
        {
            return new Customer(vatNumber);
        }
    }
}
