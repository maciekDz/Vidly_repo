using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
        public List<Genre> Genres { get; set; }

        public string FormTitle
        {
            get
            {
                return MovieId == 0 ? "New Movie" : "Edit Movie";
            }
        }
        
        public MovieViewModel()
        {
            MovieId = 0;
        }
        public MovieViewModel(Movie movie)
        {
            MovieId = movie.MovieId;
            MovieName = movie.MovieName;
            RelaseDate = movie.RelaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        public int? MovieId { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Required]
        [Display(Name = "Relase Date")]
        [DataType(DataType.Date)] //format set globaly in Global.asax
        public DateTime? RelaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }


    }
}