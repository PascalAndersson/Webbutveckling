using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L6.Models
{
    public class DataManager
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer { ID = 1, CompanyName = "Bo", City = "Stockholm"},
            new Customer { ID = 2, CompanyName = "Li", City = "Gothenburg"},
            new Customer { ID = 3, CompanyName = "An", City = "Malmo"},
        };

        public static CustomersIndexVM[] ListCustomers()
        {
            return customers.Select(o => new CustomersIndexVM
            {
                Id = o.ID,
                CompanyName = o.CompanyName,
                City = o.City
            })
            .ToArray();
        }

        public static CustomersIndexVM GetCustomerById(int id)
        {
            Customer cust = customers.SingleOrDefault(c => c.ID == id);

            CustomersIndexVM customerIndexVM = new CustomersIndexVM
            {
                CompanyName = cust.CompanyName,
                City = cust.City
            };

            return customerIndexVM;
        }
    }
}
