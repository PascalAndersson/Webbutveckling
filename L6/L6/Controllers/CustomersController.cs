using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L6.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace L6.Controllers
{
    public class CustomersController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = DataManager.ListCustomers();
            return View(model);
        }

        public IActionResult GetCustomerHtml(int id)
        {
            var viewModel = DataManager.GetCustomerById(id);
            return PartialView("CustomerBox", viewModel);
        }
    }
}
