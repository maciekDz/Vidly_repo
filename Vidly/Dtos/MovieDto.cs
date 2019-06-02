using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int MovieId { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        [DataType(DataType.Date)] //format set globaly in Global.asax
        public DateTime RelaseDate { get; set; }

        [Required]
        [DataType(DataType.Date)] //format set globaly in Global.asax
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
    }
}