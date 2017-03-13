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
            new Customer { ID = 1, FirstName = "Bo", LastName = "Test1"},
            new Customer { ID = 2, FirstName = "Li", LastName = "Test2"},
            new Customer { ID = 3, FirstName = "An", LastName = "Test3"},
        };

        public static CustomersIndexVM[] ListCustomers()
        {
            return customers.Select(o => new CustomersIndexVM
            {
                FirstName = o.FirstName,
                LastName = o.LastName
            })
            .ToArray();
        }
    }
}
