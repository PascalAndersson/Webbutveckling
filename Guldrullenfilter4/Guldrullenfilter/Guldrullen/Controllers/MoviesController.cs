using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Guldrullen.Models.Entities;
using Guldrullen.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Guldrullen.Controllers
{
    public class MoviesController : Controller
    {

        GuldrullenContext context;

        public MoviesController(GuldrullenContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            MovieDisplayAdvancedVM viewModel = new MovieDisplayAdvancedVM();
            viewModel.SearchBox = (string)TempData["Search"];
            
            string genreCheckbox="";

            if ((string)TempData["DisplayAction"] == "True")
            {
                genreCheckbox += "Action";
            }

            if ((string)TempData["DisplayComedy"] == "True")
            {
                genreCheckbox += "Comedy";
            }

            if ((string)TempData["DisplayRomance"] == "True")
            {
                genreCheckbox += "Romance";
            }

            if (viewModel.SearchBox != null || genreCheckbox != "")
                viewModel.ListViewModels = context.SearchMovies(viewModel.SearchBox,genreCheckbox);
            else
                viewModel.ListViewModels = context.ListMovies();

            TempData["DisplayAction"] = "";
            TempData["DisplayComedy"] = "";
            TempData["DisplayRomance"] = "";
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(MovieDisplayAdvancedVM viewModel)
        {
            TempData["Search"] = viewModel.SearchBox;
            TempData["DisplayAction"] = viewModel.DisplayActionBool.ToString();     //Spara action boolen
            TempData["DisplayComedy"] = viewModel.DisplayComedyBool.ToString();     //Spara action boolen
            TempData["DisplayRomance"] = viewModel.DisplayRomanceBool.ToString();       //Spara action boolen


            return RedirectToAction(nameof(MoviesController.Index));
        }

        public IActionResult Review()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            context.AddMovie(viewModel);
            return RedirectToAction(nameof(MoviesController.Index));
        }

        public IActionResult Reviews(int id)
        {
            var test = new MovieReviewAdvancedVM();
            test.ListViewModels = context.ListReviews(id);
            test.FormViewModel = context.GetMovieToShowOnReviewPage(id);

            return View(test);
        }
    }
}
