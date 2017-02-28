using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using L3.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace L3.Controllers
{
    public class PeopleController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = DataManager.ListPeople();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost] 
        //public IActionResult Create(Person person)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return View(person);
        //    }

        //    DataManager.AddPerson(person);
        //    return RedirectToAction(nameof(PeopleController.Index));
        //}

        [HttpPost]
        public IActionResult Create(PeopleCreateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            DataManager.AddPerson(viewModel);
            return RedirectToAction(nameof(PeopleController.Index));
        }
    }

}
