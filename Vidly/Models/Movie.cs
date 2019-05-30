using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        [Display(Name = "Relase Date")]
        [DataType(DataType.Date)] //format set globaly in Global.asax
        public DateTime RelaseDate { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)] //format set globaly in Global.asax
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

    }
}