using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;

namespace Guldrullen.Models.Entities
{
    public partial class GuldrullenContext
    {
        public MovieDisplayVM[] SearchMovies(string title, string genre)
        {
            MovieDisplayVM[] searchedMovies;

            if ((genre == "Action" || genre == "Comedy" || genre == "Romance") && (title == null))
                searchedMovies = GetSingleGenreWithoutTextSearch(genre);

            else if (genre == "Action" || genre == "Comedy" || genre == "Romance")
                searchedMovies = GetSingleGenreWithTextSearch(title, genre);
            
            else if ((genre == "ActionComedy") && (title == null))
                searchedMovies = GetActionAndComedyMoviesWithoutSearchtext();

            else if (genre == "ActionComedy")
                searchedMovies = GetActionAndComedyWithSearchtext(title);

            else if ((genre == "ActionRomance") && (title == null))
                searchedMovies = GetActionAndRomanceWithoutSearchtext();

            else if (genre == "ActionRomance")
                searchedMovies = GetActionAndRomanceWithSearchtext(title);


            else if ((genre == "ComedyRomance") && (title == null))
                searchedMovies = GetComedyAndRomanceWithoutSearchtext();

            else if (genre == "ComedyRomance")
                searchedMovies = GetComedyAndRomanceWithSearchtext(title);

            else if ((genre == "ActionComedyRomance") && title == null)
                searchedMovies = GetActionAndComedyAndRomanceWithouteSearchtext();
            else if (genre == "ActionComedyRomance")
                searchedMovies = GetActionAndComedyAndRomanceWithSearchtext(title);
            else
                searchedMovies = GetAllGenresWithSearchtext(title);
            return CountRate(searchedMovies);
        }

        private MovieDisplayVM[] CountRate(MovieDisplayVM[] rate)
        {
            foreach (var movie in rate)
            {
                var ratings = this.Review.Where(o => o.MovieId == movie.Id).Select(o => o.Rate).ToArray();

                if (ratings.Length > 0)
                {
                    movie.Rate = ratings.Average();
                    if (movie.Rate.ToString().Length > 2)
                        try
                        {
                            movie.Rate = double.Parse(movie.Rate.ToString().Remove(3));
                        }
                        catch (Exception) { }
                }
            }
            return rate;
        }

        private MovieDisplayVM[] GetAllGenresWithSearchtext(string title)
        {
            return Movie.Where(m => m.Title.Contains(title))
            .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }
        
        private MovieDisplayVM[] GetActionAndComedyAndRomanceWithSearchtext(string title)
        {
            return Movie.Where(m => m.Genre == "Action" || m.Genre == "Comedy" || m.Genre == "Romance").Where(m => m.Title.Contains(title))
                            .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private MovieDisplayVM[] GetActionAndComedyAndRomanceWithouteSearchtext()
        {
            return Movie.Where(m => m.Genre == "Action" || m.Genre == "Comedy" || m.Genre == "Romance")
             .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private MovieDisplayVM[] GetComedyAndRomanceWithSearchtext(string title)
        {
            return Movie.Where(m => m.Genre == "Comedy" || m.Genre == "Romance").Where(m => m.Title.Contains(title))
             .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private MovieDisplayVM[] GetComedyAndRomanceWithoutSearchtext()
        {
            return Movie.Where(m => m.Genre == "Comedy" || m.Genre == "Romance")
                             .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private MovieDisplayVM[] GetActionAndRomanceWithSearchtext(string title)
        {
            return Movie.Where(m => m.Genre == "Action" || m.Genre == "Romance").Where(m => m.Title.Contains(title))
             .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private MovieDisplayVM[] GetActionAndRomanceWithoutSearchtext()
        {
            return Movie.Where(m => m.Genre == "Action" || m.Genre == "Romance")
                             .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private MovieDisplayVM[] GetActionAndComedyWithSearchtext(string title)
        {
            return Movie.Where(m => m.Genre == "Action" || m.Genre == "Comedy").Where(m => m.Title.Contains(title))
                             .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private MovieDisplayVM[] GetActionAndComedyMoviesWithoutSearchtext()
        {
            return Movie.Where(m => m.Genre == "Action" || m.Genre == "Comedy")
                             .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private MovieDisplayVM[] GetSingleGenreWithTextSearch(string title, string genre)
        {
            return Movie.Where(m => m.Title.Contains(title) && m.Genre == genre)
                                 .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private MovieDisplayVM[] GetSingleGenreWithoutTextSearch(string genre)
        {
            return Movie.Where(m => m.Genre == genre)
                                 .Select(m => ConvertToMovieDisplayVM(m)).ToArray();
        }

        private static MovieDisplayVM ConvertToMovieDisplayVM(Movie m)
        {
            return new MovieDisplayVM
            {
                Title = m.Title,
                Id = m.Id,
                Genre = m.Genre,
                Length = m.Length
            };
        }
    }
}