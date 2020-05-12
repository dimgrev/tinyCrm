using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TinyCrm.Core.Data;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Options;
using TinyCrm.Web.Models;

namespace TinyCrm.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            using (var context = new TinyCrmDbContext())
            {
                var customerService = new CustomerService(context);

                var customer = customerService.SearchCustomers(
                    new SearchCustomerOptions()
                    {
                        CustomerId = 1
                    }).SingleOrDefault();

                return Json(customer);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
