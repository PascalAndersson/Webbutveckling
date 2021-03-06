﻿using System;
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

            
            
            if (viewModel.SearchBox == null)
                viewModel.ListViewModels = context.ListMovies("","");
            else
                viewModel.ListViewModels = context.ListMovies(viewModel.SearchBox,genreCheckbox);
                
            return View(viewModel);

            #region Test (bra egentligen)
            //else if (viewModel.DisplayAction)
            //    viewModel.ListViewModels = context.ListMovies("Action");

            //else if (viewModel.DisplayRomance)
            //    viewModel.ListViewModels = context.ListMovies("Romance");
            //context.ListMovies("Action").CopyTo(viewModel.ListViewModels, 0);
            //context.ListMovies("Romance").CopyTo(viewModel.ListViewModels, 1);
            //if (!viewModel.DisplayAction)
            // Array.Copy(context.ListMovies("Romance"), viewModel.ListViewModels, context.ListMovies("Romance").Length);
            // viewModel.ListViewModels = context.ListMovies("Action");
            // if (!viewModel.DisplayAction)
            //   Array.Copy(context.ListMovies("Action"), viewModel.ListViewModels, context.ListMovies("Action").Length);
            #endregion
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
