using System.Linq;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer CreateCustomer(
            CreateCustomerOptions options);
        IQueryable<Customer> SearchCustomers(
            SearchCustomerOptions options);
        bool UpdateCustomer(
            int id, UpdateCustomerOptions options);
        IQueryable<Customer> GetCustomerById(
            int id);
    }
}
