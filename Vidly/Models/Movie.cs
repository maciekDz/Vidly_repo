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

        [Required]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Relase Date")]
        [DataType(DataType.Date)] //format set globaly in Global.asax
        public DateTime RelaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)] //format set globaly in Global.asax
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }

    }
}