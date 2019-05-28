﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{ MovieId=1,MovieName="LOTR"},
                new Movie{ MovieId=2,MovieName="GOT"}
            };
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { MovieName="Shrek"};
            var customers = new List<Customer>
            {
                new Customer{ CustomerId=1,CustomerName="Mike"},
                new Customer{ CustomerId=2,CustomerName="Josh"},
                new Customer{ CustomerId=3,CustomerName="Dave"},
                new Customer{ CustomerId=4,CustomerName="Rob"},
                new Customer{ CustomerId=5,CustomerName="Jon"}
            };

            var vm = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(vm);
            
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex,string sortBy)
        {
            var movies = GetMovies();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = GetMovies();
            var movie = movies.Where(m => m.MovieId== id).FirstOrDefault();

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/" + month);
        }
    }
}