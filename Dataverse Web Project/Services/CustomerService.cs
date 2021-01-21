using System;
using System.Collections.Generic;
using System.Linq;
using Dataverse_Web_Project.Data;
using Dataverse_Web_Project.Models;
using Dataverse_Web_Project.Options;

namespace Dataverse_Web_Project.Services
{
    public class CustomerService: ICustomerService
    {

        private readonly DataverseDBContext dbContext;

        public CustomerService(DataverseDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<CustomerOption> GetCustomers()
        {
            List<Customer> customers = dbContext.Customers.ToList();
            List<CustomerOption> customersOpt = new List<CustomerOption>();
            customers.ForEach(customer => customersOpt.Add(new CustomerOption
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Telephone = customer.Telephone,
                Email = customer.Email,
                Address = customer.Address,
                Id = customer.Id
            })); ;
            return customersOpt;

        }

        public CustomerOption GetCustomerById(int id)
        {
            Customer customer = dbContext.Customers.Find(id);
            return new CustomerOption
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Telephone = customer.Telephone,
                Email = customer.Email,
                Address = customer.Address,
                Id = customer.Id
            };
        }

        public CustomerOption CreateCustomer(CustomerOption customerOpt)
        {
            //if (string.IsNullOrWhiteSpace(customerOpt.FirstName) ) return null;

            //if (string.IsNullOrWhiteSpace(customerOpt.Email) ||
            // !customerOpt.Email.Contains("@")) return null;

            Customer customer = new Customer
            {
                FirstName = customerOpt.FirstName,
                LastName = customerOpt.LastName,
                Telephone = customerOpt.Telephone,
                Email = customerOpt.Email,
                Address = customerOpt.Address,
                Id = customerOpt.Id
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            return new CustomerOption
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Telephone = customer.Telephone,
                Email = customer.Email,
                Address = customer.Address,
                Id = customer.Id
            };


        }

        public CustomerOption UpdateCustomer(CustomerOption customerOpt,int id)
        {
            Customer customer = dbContext.Customers.Find(id);
            customerOptToCustomer(customerOpt, customer);

            dbContext.SaveChanges();

            return new CustomerOption
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Telephone = customer.Telephone,
                Email = customer.Email,
                Address = customer.Address,
                Id = customer.Id

            };
        }
        private static void customerOptToCustomer(CustomerOption customerOpt, Customer customer)
        {
            customer.FirstName = customerOpt.FirstName;
            customer.LastName = customerOpt.LastName;
            customer.Address = customerOpt.Address;
            customer.Email = customerOpt.Email;
            customer.Telephone = customerOpt.Telephone;

        }

        public bool DeleteCustomer(int id)
        {
            Customer customer = dbContext.Customers.Find(id);
            if (customer == null) return false;
            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
            return true;
        }

    }
}
