using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dataverse_Web_Project.Options;

namespace DataVerseMVC.Models
{
    public class CustomerModel
    {
        public List <CustomerOption> Customers { get; set; }
    }

    public class CustomerOptionModel
    {
        public CustomerOption customer { get; set; }
    }
}
