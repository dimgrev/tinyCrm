using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Interfaces;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Web.Controllers
{
    public class CustomerController : Controller
    {
        private TinyCrmDbContext dbcontext_;
        private ICustomerService customerService_;
        public CustomerController()
        {
            dbcontext_ = new TinyCrmDbContext();
            customerService_ = new CustomerService(dbcontext_);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerOptions options)
        {
            var result = customerService_.CreateCustomer(options);

            if (result == null)
            {
                return NoContent();
            }

            return Json(result);
        }

        [HttpPatch("Update{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCustomerOptions options)
        {
            var result = customerService_.UpdateCustomer(id, options);

            if (result == false)
            {
                return BadRequest();
            }

            return Json(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            var result = customerService_.DeleteCustomer(id);

            if (result == false)
            {
                return BadRequest();
            }

            return Json(result);
        }

        [HttpGet]
        public IActionResult Search(SearchCustomerOptions options)
        {
            var result = customerService_
                .SearchCustomers(options)
                .ToList();

            return Json(result);
        }

        public IActionResult GetById(int? id)
        {
            //400 Bad Request
            //403 Forbidden
            //404 Not Found
            //500 Internal Server Error

            if (id == null)
            {
                return BadRequest();
            }

            var customer = customerService_
                .SearchCustomers(new SearchCustomerOptions()
                {
                    CustomerId = id,
                })
                .SingleOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return Json(customer);
        }

        //[HttpPost] se ti verb 8elw na apantaei h action (mono se auto)
        public IActionResult Index()
        {
            var customerList = customerService_
                .SearchCustomers(new SearchCustomerOptions())
                .ToList();

            return Json(customerList);
        }
    }
}