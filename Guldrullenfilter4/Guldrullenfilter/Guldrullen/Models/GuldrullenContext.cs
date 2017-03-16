using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;

namespace Guldrullen.Models.Entities
{
    public partial class GuldrullenContext : DbContext
    {
        public GuldrullenContext(DbContextOptions<GuldrullenContext> options) : base(options)
        {

        }

        public MovieDisplayVM[] ListMovies()
        {
            var movieList = Movie
            .Select(m => new MovieDisplayVM
            {
                Title = m.Title,
                Id = m.Id,
                Genre = m.Genre,
                Length = m.Length
            }).ToArray();
            return movieList;
        }

        public MovieDisplayVM[] SearchMovies(string title, string genre)
        {

            if ((genre == "Action" || genre == "Comedy" || genre == "Romance") && (title == null))
            {
                var movieList = Movie.Where(m => m.Genre == genre)
                    .Select(m => new MovieDisplayVM
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Genre = m.Genre,
                        Length = m.Length,
                    })
                    .ToArray();
                return movieList;
            }



            else if (genre == "Action" || genre == "Comedy" || genre == "Romance")
            {
                var movieList = Movie.Where(m => m.Title.Contains(title) && m.Genre == genre)
                    .Select(m => new MovieDisplayVM
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Genre = m.Genre,
                        Length = m.Length,
                    })
                    .ToArray();
                return movieList;
            }

            else if ((genre == "ActionComedy") && (title == null))
            {
                var movieList = Movie.Where(m => m.Genre == "Action" || m.Genre == "Comedy")
                .Select(m => new MovieDisplayVM
                {
                    Title = m.Title,
                    Id = m.Id,
                    Genre = m.Genre,
                    Length = m.Length
                }).ToArray();
                return movieList;
            }

            else if (genre == "ActionComedy")
            {
                var movieList = Movie.Where(m => m.Genre == "Action" || m.Genre == "Comedy").Where(m => m.Title.Contains(title))
                .Select(m => new MovieDisplayVM
                {
                    Title = m.Title,
                    Id = m.Id,
                    Genre = m.Genre,
                    Length = m.Length
                }).ToArray();
                return movieList;
            }

            else if ((genre == "ActionRomance") && (title == null))
            {
                var movieList = Movie.Where(m => m.Genre == "Action" || m.Genre == "Romance")
                .Select(m => new MovieDisplayVM
                {
                    Title = m.Title,
                    Id = m.Id,
                    Genre = m.Genre,
                    Length = m.Length
                }).ToArray();
                return movieList;
            }

            else if (genre == "ActionRomance")
            {
                var movieList = Movie.Where(m => m.Genre == "Action" || m.Genre == "Romance").Where(m => m.Title.Contains(title))
                .Select(m => new MovieDisplayVM
                {
                    Title = m.Title,
                    Id = m.Id,
                    Genre = m.Genre,
                    Length = m.Length
                }).ToArray();
                return movieList;
            }


            else if ((genre == "ComedyRomance") && (title == null))
            {
                var movieList = Movie.Where(m => m.Genre == "Comedy" || m.Genre == "Romance")
                .Select(m => new MovieDisplayVM
                {
                    Title = m.Title,
                    Id = m.Id,
                    Genre = m.Genre,
                    Length = m.Length
                }).ToArray();
                return movieList;
            }

            else if (genre == "ComedyRomance")
            {
                var movieList = Movie.Where(m => m.Genre == "Comedy" || m.Genre == "Romance").Where(m => m.Title.Contains(title))
                .Select(m => new MovieDisplayVM
                {
                    Title = m.Title,
                    Id = m.Id,
                    Genre = m.Genre,
                    Length = m.Length
                }).ToArray();
                return movieList;
            }

            else if ((genre == "ActionComedyRomance") && title == null)
            {
                var movieList = Movie.Where(m => m.Genre == "Action" || m.Genre == "Comedy" || m.Genre == "Romance")
                .Select(m => new MovieDisplayVM
                {
                    Title = m.Title,
                    Id = m.Id,
                    Genre = m.Genre,
                    Length = m.Length
                }).ToArray();
                return movieList;
            }
            else if (genre == "ActionComedyRomance")
            {
                var movieList = Movie.Where(m => m.Genre == "Action" || m.Genre == "Comedy" || m.Genre == "Romance").Where(m => m.Title.Contains(title))
                .Select(m => new MovieDisplayVM
                {
                    Title = m.Title,
                    Id = m.Id,
                    Genre = m.Genre,
                    Length = m.Length
                }).ToArray();
                return movieList;
            }

            else
            {
                var movieList = Movie.Where(m => m.Title.Contains(title))
                .Select(m => new MovieDisplayVM
                {
                    Title = m.Title,
                    Id = m.Id,
                    Genre = m.Genre,
                    Length = m.Length
                }).ToArray();
                return movieList;
            }

            //var ret = Movie
            //    .Select(m => new MovieDisplayVM
            //    {
            //        Id = m.Id,
            //        Title = m.Title,
            //        Genre = m.Genre,
            //        Length = m.Length,
            //    })


            //    .Where(m => m.Title.Contains(title))
            //    .OrderBy(m => m.Title)
            //.ToArray();

            //foreach (var movie in ret)
            //{
            //    var ratings = this.Review
            //        .Where(o => o.MovieId == movie.Id)
            //        .Select(o => o.Rate)
            //        .ToArray();

            //    if (ratings.Length > 0)
            //    {
            //        movie.Rate = ratings
            //              .Average();
            //        if (movie.Rate.ToString().Length > 2)
            //            try
            //            {
            //                movie.Rate = double.Parse(movie.Rate.ToString().Remove(3));
            //            }
            //            catch (Exception) { }
            //    }
            //}
            ////return ret;
        }


        public void AddMovie(MovieCreateVM viewModel)
        {
            var movieToAdd = new Movie
            {
                Title = viewModel.Title,
                Length = viewModel.Length,
                Genre = viewModel.Genre,
            };

            Movie.Add(movieToAdd);
            SaveChanges();
        }


        public MovieReviewVM[] ListReviews(int id)
        {
            //var movieTitle = Movie.SingleOrDefault(m => m.Id == id).Title;
            var reviews = Review
                .Where(c => c.MovieId == id)
                .Select(m => new MovieReviewVM
                {
                    ReviewTitle = m.Title,
                    Text = m.Text,
                    Rate = m.Rate,
                    Id = m.Id,
                    // Movie = movieTitle,
                }).ToArray();


            return reviews;

        }

        public string GetMovie(int id)
        {
            string movieTitle = Movie.SingleOrDefault(m => m.Id == id).Title;
            return movieTitle;
        }

        internal MovieDisplayVM GetMovieToShowOnReviewPage(int id)
        {
            var movie = Movie.SingleOrDefault(c => c.Id == id);
            return new MovieDisplayVM
            {
                Title = movie.Title,
                Id = movie.Id
            };
        }
    }
}