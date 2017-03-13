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
            new Customer { ID = 1, CompanyName = "Bo"},
            new Customer { ID = 2, CompanyName = "Li"},
            new Customer { ID = 3, CompanyName = "An"},
        };

        public static CustomersIndexVM[] ListCustomers()
        {
            return customers.Select(o => new CustomersIndexVM
            {
                Id = o.ID,
                CompanyName = o.CompanyName,
            })
            .ToArray();
        }
    }
}
