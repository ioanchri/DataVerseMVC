using System;
using System.Collections.Generic;
using System.Text;
using Dataverse_Web_Project.Options;

namespace Dataverse_Web_Project.Services
{
    public interface ICustomerService
    {
        List<CustomerOption> GetCustomers();
        CustomerOption GetCustomerById(int id);
        CustomerOption CreateCustomer(CustomerOption customerOpt);
        CustomerOption UpdateCustomer(CustomerOption customerOpt,int id);
        bool DeleteCustomer(int id);


    }
}
