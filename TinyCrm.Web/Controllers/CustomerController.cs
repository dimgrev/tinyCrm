using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TinyCrm.Core.Services.Interfaces;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Web.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        //private TinyCrmDbContext dbcontext_;
        private ICustomerService customerService_;
        public CustomerController(ICustomerService customerService)
        {
            //dbcontext_ = new TinyCrmDbContext();
            customerService_ = customerService; //new CustomerService(dbcontext_);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerOptions options)
        {
            var result = customerService_.CreateCustomer(options);

            if (!result.Success)
            {
                return StatusCode((int)result.ErrorCode,
                    result.ErrorText);
            }

            //if (result.ErrorCode == )
            //{

            //}

            return Json(result.Data);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCustomerOptions options)
        {
            var result = customerService_.UpdateCustomer(id, options);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int? id)
        {
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

            return View(customer);
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

        [HttpPost]
        public IActionResult Search(SearchCustomerOptions options)
        {
            var result = customerService_
                .SearchCustomers(options)
                .ToList();

            return Json(result);
        }

        [HttpGet("{id}")]
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

            //if (customer == null)
            //{
            //    return NotFound();
            //}

            return View(customer);
        }

        //[HttpPost] se ti verb 8elw na apantaei h action (mono se auto)
        [HttpGet]
        public IActionResult Index()
        {
            var customerList = customerService_
                .SearchCustomers(new SearchCustomerOptions())
                .ToList();

            return Json(customerList);
        }
    }
}