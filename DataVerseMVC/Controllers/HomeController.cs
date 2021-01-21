using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dataverse_Web_Project.Options;
using Dataverse_Web_Project.Services;
using DataVerseMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataVerseMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService customerService;

        public HomeController(ILogger<HomeController> logger,ICustomerService _customerService)
        {
            _logger = logger;
            customerService = _customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       

        public IActionResult Customers()
        {
            try
            {
                List<CustomerOption> customers = customerService.GetCustomers();
                CustomerModel customerModel = new CustomerModel { Customers = customers };
                return View(customerModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult DeleteCustomerFromList([FromRoute] int id)
        {
            try
            {
                customerService.DeleteCustomer(id);

                return Redirect("/Home/Customers");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        public IActionResult UpdateCustomer([FromRoute] int id)
        {
            try
            {
                CustomerOption customerOpt = customerService.GetCustomerById(id);
                CustomerOptionModel model = new CustomerOptionModel { customer = customerOpt };
                return View(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }    


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
