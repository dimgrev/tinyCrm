using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TinyCrm.Core.Data;
using TinyCrm.Core.Services;
using TinyCrm.Core.Services.Interfaces;
using TinyCrm.Core.Services.Options;
using TinyCrm.Web.Models;

namespace TinyCrm.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICustomerService customerService_;
        private IProductService productService_;
        public HomeController(ICustomerService customerService, IProductService productService)
        {
            customerService_ = customerService;
            productService_ = productService;
        }

        public IActionResult Index()
        {
            var customers = customerService_.SearchCustomers(new SearchCustomerOptions()).ToList();
            var products = productService_.SearchProducts(new SearchProductOptions()).ToList();

            var cplist = new CPmodel()
            {
                Customers = customers,
                Products = products
            };

            return View(cplist);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
