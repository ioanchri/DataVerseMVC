using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dataverse_Web_Project.Options;
using Dataverse_Web_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataVerseMVC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }


        [HttpGet]
        public List<CustomerOption> GetCustomers()
        {
            return customerService.GetCustomers();
        }

        [HttpPost]
        public CustomerOption AddCustomer(CustomerOption customerOpt)
        {
            CustomerOption customerOption = customerService.CreateCustomer(customerOpt);
            return customerOption;
        }

        [HttpPut("{id}")]
        public CustomerOption UpdateCustomer(CustomerOption customerOpt, int id)
        {
            return customerService.UpdateCustomer(customerOpt, id);

        }
        [HttpDelete("{id}")]
        public bool DeleteCustomer(int id)
        {
            return customerService.DeleteCustomer(id);
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

     

    }
}
