using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyCrm.Core.Model;

namespace TinyCrm.Web.Models
{
    public class CPmodel
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }

        public CPmodel()
        {
            Customers = new List<Customer>();
            Products = new List<Product>();
        }
    }
}
