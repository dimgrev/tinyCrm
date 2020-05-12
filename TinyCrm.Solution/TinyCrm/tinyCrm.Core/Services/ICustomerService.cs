using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
        Customer CreateCustomer(
            CreateCustomerOptions options);

        Customer UpdateCustomer(
            UpdateCustomerOptions options);

        IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options);

        Customer GetCustomerById(
            GetCustomerByIdOptions options);
    }
}
