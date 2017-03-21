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

        [HttpGet]
        public IActionResult Index()
        {
            var model = context.GetTopFiveMovies();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(MovieIndexVM model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Display()
        {
            MovieDisplayAdvancedVM viewModel = new MovieDisplayAdvancedVM();
            string genreCheckbox = SetSavedTempDataToGenreString(viewModel);

            if (viewModel.SearchBox != null || genreCheckbox != "")
                viewModel.ListViewModels = context.SearchMovies(viewModel.SearchBox, genreCheckbox);
            else
                viewModel.ListViewModels = context.ListMovies("");

            ClearTempData();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Display(MovieDisplayAdvancedVM viewModel)
        {
            SetCheckBoxValueToTempData(viewModel);
            return RedirectToAction("Display");
        }

        public IActionResult Review()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var genres = context.GetAllGenres();

            var model = new MovieCreateVM();

            model.Genres = context.GetSelectedListItem(genres);

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateVM viewModel)
        {
            var genres = context.GetAllGenres();

            viewModel.Genres = context.GetSelectedListItem(genres);

            if (!ModelState.IsValid)
                return View(viewModel);

            context.AddMovie(viewModel);
            return RedirectToAction(nameof(MoviesController.Index));
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var viewModel = new MovieReviewAdvancedVM();
            viewModel.ListViewModels = context.ListReviews(id);
            viewModel.FormViewModel = context.GetMovieToShowOnReviewPage(id);
            //test.CreateReview = context.GetMovieToShowOnReviewPage();
            viewModel.CreateReview = new ReviewCreateVM
            {
                Rates = new List<RoleVm>
                 {
                     new RoleVm {Id = 1, Rating = "1"},
                     new RoleVm {Id = 2, Rating = "2"},
                     new RoleVm {Id = 3, Rating = "3"},
                     new RoleVm {Id = 4, Rating = "4"},
                     new RoleVm {Id = 5, Rating = "5"},
                     new RoleVm {Id = 6, Rating = "6"},
                     new RoleVm {Id = 7, Rating = "7"},
                     new RoleVm {Id = 8, Rating = "8"},
                     new RoleVm {Id = 9, Rating = "9"},
                     new RoleVm {Id = 10, Rating = "10"},
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Info(ReviewCreateVM viewModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            context.AddReview(viewModel, id);
            return RedirectToAction(nameof(MoviesController.Info));
        }

        public IActionResult Edit(int id)
        {
            var model = context.GetMovieForEdit(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(MovieEditVM viewModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            context.EditMovie(viewModel, id);
            return RedirectToAction(nameof(MoviesController.Index));
        }

        private string SetSavedTempDataToGenreString(MovieDisplayAdvancedVM viewModel)
        {
            viewModel.SearchBox = (string)TempData["Search"];
            string genreCheckbox = "";
            if ((string)TempData["DisplayAction"] == "True") genreCheckbox += "Action";
            if ((string)TempData["DisplayComedy"] == "True") genreCheckbox += "Comedy";
            if ((string)TempData["DisplayRomance"] == "True") genreCheckbox += "Romance";
            return genreCheckbox;
        }

        private void SetCheckBoxValueToTempData(MovieDisplayAdvancedVM viewModel)
        {
            TempData["Search"] = viewModel.SearchBox;
            TempData["DisplayAction"] = viewModel.DisplayActionBool.ToString();     //Spara action boolen
            TempData["DisplayComedy"] = viewModel.DisplayComedyBool.ToString();     //Spara action boolen
            TempData["DisplayRomance"] = viewModel.DisplayRomanceBool.ToString();   //Spara action boolen
        }


        private void ClearTempData()
        {
            TempData["DisplayAction"] = "";
            TempData["DisplayComedy"] = "";
            TempData["DisplayRomance"] = "";
        }
    }
}
