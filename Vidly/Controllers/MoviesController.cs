using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).Where(m => m.MovieId == id).SingleOrDefault();

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var vm = new MovieViewModel
            {
                Movie = new Movie
                {
                    NumberInStock=_context.Movies.Max(n=>n.NumberInStock)+1
                },
                Genres = genres
            };
            return View("MovieForm", vm);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieInDb = _context.Movies.Where(m => m.MovieId == movie.MovieId).Single();
                    movieInDb.MovieName = movie.MovieName;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.RelaseDate = movie.RelaseDate;
                    movieInDb.DateAdded = movie.DateAdded;
                    movieInDb.NumberInStock = movie.NumberInStock;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Movies");
            }
            else
            {
                var vm = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm",vm);
            }
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);
            var genres = _context.Genres.ToList();
            var vm = new MovieViewModel
            {
                Movie = movie,
                Genres = genres
            };

            if (movie == null)
                return HttpNotFound();

            return View("MovieForm", vm);
        }

    }
}